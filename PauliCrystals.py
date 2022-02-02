# -*- coding: utf-8 -*-
"""
Created on Mon Jan 24 19:52:52 2022

@author: 46764
"""

import numpy as np
import scipy.special as sc
import itertools
import math
import sys
from tqdm import tqdm
import jdc ## a tool that allows one to extend classes over multiple cells
import matplotlib.pyplot as plt
from scipy.optimize import fmin
from numpy.random import rand
from collections import Counter
import sympy
import scipy

#%%

def Hermite(x, n):
    return sc.eval_hermite(n, x)

# Normalisation factor of 1D harmonic function
def normHarmonicFactor(n, wx):
    return (2**n * math.factorial(n) * math.sqrt(math.pi/wx))**(-1/2)

# Harmonic 1D WF
def Harmonic(x, n, w):
    return  normHarmonicFactor(n,w) * np.e**(-w * (x**2)/2) * Hermite(math.sqrt(w)*x, n)

# Single Particle 2D Harmonic
def Harmonic2D(x, y, n_x, n_y, delta):
    w_x = np.sqrt(delta) # Assumes that $\omega_0^2 = 1$
    w_y = 1/w_x
    return Harmonic(x, n_x, w_x)*Harmonic(y, n_y, w_y)

#%%

def Energy2D(n_x,n_y,delta):
    E = (n_x + 0.5)*np.sqrt(delta) + (n_y + 0.5)/np.sqrt(delta)
    return E

## The function below finds the N energetically lowest 2DHO orbitals that may be used to contruct the Slater determinant
## If the provided number of particles do not form a closed shell, a warning is issued
def lowestOrbitals(delta,N):
    # N represents the number of particles
    # delta represents the deformation factor
    orbitalIndices = list(itertools.product(range(30),range(30)))
    orbitalEnergies = []
    for i in orbitalIndices:
        e = Energy2D(i[0],i[1],delta)
        index = orbitalIndices.index(i)
        orbitalEnergies.append((e,index))
    sortedEnergies = sorted(orbitalEnergies, key=lambda x: x[0])
    if (np.isclose(sortedEnergies[N-1][0],sortedEnergies[N][0])):
        print(f"{N} particles at a deformation factor {delta} do not form a closed shell.")
    lowestOrbitals = []
    for i in range(N):
        orbitalIndex = sortedEnergies[i][1]
        lowestOrbitals.append(orbitalIndices[orbitalIndex])
    return lowestOrbitals

#%%

def centerMass(vector):
    shape = vector.shape
    xCM = np.mean(vector[:,0])
    yCM = np.mean(vector[:,1])
    CoM = np.full((shape[0],shape[1]),[xCM,yCM])
    return CoM

def Rotation2D(vector,angle):
    vector = np.matrix(vector).T
    R = np.array([[np.cos(angle), -np.sin(angle)]
                ,[np.sin(angle),  np.cos(angle)]])
    return np.array((R*vector).T)

def Reflectx(vector):
    _vector = np.copy(vector)
    _vector[:,0] *= -1
    return _vector

def Reflecty(vector):
    _vector = np.copy(vector)
    _vector[:,1] *= -1
    return _vector

def Reflectxy(vector):
    _vector = np.copy(vector)
    _vector[:,0] *= -1
    _vector[:,1] *= -1
    return _vector


def removeOriginParticle(vector):
    N = vector.shape[0]
    vecLen = list(vector[:,0]**2 + vector[:,1]**2)
    minIndex = vecLen.index(min(vecLen))
    vector = np.delete(vector,2 * minIndex)
    vector = np.delete(vector,2 * minIndex)
    vector = vector.reshape(N-1,2)
    return vector


def TupleIt(vector):
    return [(i[0],i[1]) for i in vector]


def sortArray(vector):
    return vector[np.argsort(vector[:, 1])]


#%%
    
class PauliCrystal:
    def __init__(self, N, delta):
        self.N = N
        self.delta = delta
        self.lowestOrbs = lowestOrbitals(self.delta,self.N)
        self.w_x = np.sqrt(self.delta) # Assumes that $\omega_0^2 = 1$
        self.w_y = 1/self.w_x
        self.refConfig = np.random.rand(self.N,2)
        self.refAngles = np.arctan2(self.refConfig[:,1],self.refConfig[:,0])
        self.rotSym = False
        self.transSym = False
        self.originParticle = False

    def SymCheck(self):
        probRef = self.Slater(self.refConfig)**2
        randomAngles = 2*np.pi*rand(4)
        print(randomAngles)
        probRotations = [self.Slater(Rotation2D(self.refConfig,i))**2 for i in randomAngles]
        print("Rotation Check: ", np.array(probRotations) - np.full((4,),probRef))
        probReflections = []
        probReflections.append(self.Slater(Reflectx(self.refConfig))**2)
        probReflections.append(self.Slater(Reflecty(self.refConfig))**2)
        probReflections.append(self.Slater(Reflectxy(self.refConfig))**2)
        print("Reflection Check: ", np.array(probReflections) == np.full((3,),probRef)) 
        rotResponse = input("Is the system rotationally symmetric?\nYes (y) No (n)")
        if rotResponse == "y":
            self.rotSym = True
        else:
            transResponse = input("Is the system reflectively symmetric?\nYes (y) No (n)")
            if transResponse == "y":
                self.transSym = True

    def Slater(self,tup): # tup will be an array of shape (N,2) with N particles and each particle an x,y pair
        if tup.shape != (self.N,2):
            print("Tuple provided does not contain N two-dimensional coordinates!")
            raise SystemExit(0)
        X = np.empty((self.N,self.N))
        for i in range(self.N): # Iterates over the N particles
            for j in range(self.N): # Iterates over the N orbitals
                x_N = tup[i][0] 
                y_N = tup[i][1]
                n_x = self.lowestOrbs[j][0]
                n_y = self.lowestOrbs[j][1]
                X[i,j] = Harmonic2D(x_N,y_N,n_x,n_y,self.delta)
        return ((1/np.sqrt(math.factorial(self.N))) * scipy.linalg.det(X))
    
    def MonteCarlo(self,n):
        # A random config is chosen to initiate the chain and the probability is calculated
        config_0 = np.random.rand(self.N,2)
        config_max = config_0
        prob_max = self.Slater(config_max)
        ### A million configs are generated and each config is checked to see if it has probability greater than 
        ### max probability. To optimize the process, a constraint is used where only center-of-mass corrected configs
        ### are used.        
        for i in tqdm(range(n),desc = "Running MonteCarlo"):
            config_1 = np.random.rand(self.N,2)
            config_1 = config_1 - centerMass(config_1)
            prob_1 = self.Slater(config_1)
            if prob_1 > prob_max:
                config_max = config_1
                prob_max = self.Slater(config_max)
        self.refConfig = config_max
        self.refAngles = np.arctan2(self.refConfig[:,1],self.refConfig[:,0])
        return config_max
    
    def Metropolis(self,n1):
        self.refConfig = self.FindRefConfig()
        chain = [6*rand(self.N,2)-3]
        for i in tqdm(range(1, n1), desc = "Running Metropolis"):
            Y = 6*rand(self.N,2)-3
            Y = Y - centerMass(Y)
            #lastConfig = list(chain)[-1]
            pY = self.Slater(Y)
            pX = self.Slater(chain[i-1])
            p = pY/pX
            if p > 1:  # config transition condition
                #chain[tuple(Y.flatten())] = 1
                chain.extend([Y])
            else:
                m = np.random.uniform(0, 1)
                if m > p:
                    #chain[lastConfig] += 1
                    chain.extend([chain[i-1]])
                else:
                    chain.extend([Y])
                    #chain[tuple(Y.flatten())] = 1
        return np.array(chain)
    
    def MSE_reflect(self,vector):
        optConfig = sortArray(self.refConfig)
        vector = sortArray(vector)
        d0 = np.sum(((vector - optConfig)**2).flatten())
        d1 = np.sum(((vector - Reflectx(optConfig))**2).flatten())
        d2 = np.sum(((vector - Reflecty(optConfig))**2).flatten())
        d3 = np.sum(((vector - Reflectxy(optConfig))**2).flatten())
        return min([d0,d1,d2,d3])
    
    def ParityCondition(self, vector):
        vals=[vector,Reflectx(vector),Reflecty(vector),Reflectxy(vector)]
        MSEvals=[self.MSE_reflect(i) for i in vals]
        return vals[MSEvals.index(min(MSEvals))]
    
    def MSE(self, vector):
        if self.originParticle == True and self.transSym == False:
            vector = removeOriginParticle(vector)
        MSE = np.sum((np.arctan2(vector[:,1],vector[:,0])- self.refAngles)**2)
        return MSE
    
    def optAlpha(self, vector): # tuple is passed into optAlpha from ProcessSnapshots method
        #vector = np.array(vector).reshape(self.N,2)
        #alphaRange = np.linspace(0,math.pi,100)
        #mseVals = [self.MSE(Rotation2D(vector,i)) for i in alphaRange]
        #return 0 + (mseVals.index(min(mseVals))/100)*np.pi
        if self.originParticle == True and self.transSym == False:
            vector = removeOriginParticle(vector)
        return -np.sum(np.arctan2(vector[:,1],vector[:,0])- self.refAngles)/self.N

    def ProcessSnapshots(self,chain): # Here, list of arrays is converted to list of tuples because it is hashable and can be counted
        newChain = []
        for i in tqdm(chain):
            newChain.append(tuple(i.flatten()))
        memo = Counter(newChain)
        uniqueConfigs = list(memo.keys())
        processedChain = []
        for i in tqdm(uniqueConfigs, desc = "Processing Snapshots"):
            vec = np.array(i).reshape(self.N,2)
            if self.rotSym == True:
                optAlpha = self.optAlpha(vec)
                processedVector = tuple(Rotation2D(vec,optAlpha).flatten())
                processedChain += [processedVector] * memo[i]
            elif self.transSym == True:
                processedVector = self.ParityCondition(vec)
                processedChain += [processedVector] * memo[i]
        tempList = []
        for i in processedChain:
            tempList.append(np.array(i).reshape(self.N,2))
        return np.array(tempList)

    def SingleParticleDensity(self,chain): # n is the number of snapshots desired to generate the density/crystal
        fig = plt.figure()
        ax = fig.add_subplot(111)
        plt.hist2d(chain[:,:,0].flatten(),chain[:,:,1].flatten(), bins=300, density=True, cmap=plt.cm.jet)
        plt.xlim(-3,3)
        plt.ylim(-3,3)
        ax.set_aspect('equal', adjustable='box')
        plt.title(f'Circular Single Particle Density, simulated, N={self.N}')
        plt.xlabel('Position along x-axis, (arbitrary units)')
        plt.ylabel('Position along y-axis, (arbitrary units)')
        plt.colorbar()
        plt.savefig("demo.png")
        plt.show()
    
    def Prob(self,tup):
        #Reshapes input from (N,2) matrix to (2N,1) vector
        tup = np.array(tup).reshape(self.N,2)
        return -self.Slater(tup)**2
    
    def FindRefConfig(self):
        tup = fmin(self.Prob,rand(2*self.N),maxiter=int(1e6))
        self.refConfig = tup.reshape(self.N,2)
        plt.figure()
        plt.xlim(-3,3)
        plt.ylim(-3,3)
        plt.grid(which='major')
        plt.plot([i[0] for i in TupleIt(self.refConfig)]
                 ,[i[1] for i in TupleIt(self.refConfig)], linestyle="None", marker = 'o', color = 'purple')
        plt.xlabel('Position along x-axis')
        plt.ylabel('Position along y-axis')
        plt.title("Most Optimal Configuration")
        responseOriginParticle = input("Is there a particle at the origin? Yes (y) No (n)\n")
        if responseOriginParticle == "y":
            self.originParticle = True
        return self.refConfig
        
    def Crystal(self,chain):
        if self.originParticle == True and self.transSym == False:
            refFlattened = removeOriginParticle(self.refConfig).flatten()
        else:
            refFlattened = self.refConfig.flatten()
        self.refAngles = [np.arctan2(refFlattened[i+1],refFlattened[i]) for i in range(0,len(refFlattened),2)]
        processedChain = self.ProcessSnapshots(chain)
        fig = plt.figure()
        ax = fig.add_subplot(111)
        plt.hist2d(processedChain[:,:,0].flatten(),processedChain[:,:,1].flatten(), bins=300, density=True, cmap=plt.cm.jet)
        plt.xlim(-3,3)
        plt.ylim(-3,3)
        ax.set_aspect('equal', adjustable='box')
        plt.title(f'Pauli Crystal, N={self.N}')
        plt.xlabel('Position along x-axis, (arbitrary units)')
        plt.ylabel('Position along y-axis, (arbitrary units)')
        plt.colorbar()
        plt.show()
    
    
   
        
#%%
x = PauliCrystal(5,3)
x.FindRefConfig()
x.SymCheck()
chain = x.Metropolis(int(1e7))
x.Crystal(chain)

#%%%











    
