class BoiteNoire:

	def __init__(self):
		
		self.grille = [[0,0,0,0,0,0],[0,0,0,-1,0,0],[0,0,0,0,0,0],[0,0,0,0,0,0],[0,1,0,0,0,0],[0,0,0,0,0,0]]
		self.spawnXY = [1,3]
		
		self.positionXY = self.spawnXY.copy()

		self.sortieXY = [1,4]
		
		self.limites = [0,5]
		
	def limMin(self):
		return self.limites[0]
		
	def limMax(self):
		return self.limites[1]
		
	def collision(self,newPos):
		if ((newPos >= self.limMin()) and (newPos <= self.limMax())):
			return False
		else:
			return True
	
	def haut(self):
	
		newPosY = self.positionXY[1] - 1
		
		if (not self.collision(newPosY)):
			self.setY(newPosY)
		
	def bas(self):
	
		newPosY = self.positionXY[1] + 1
		
		if (not self.collision(newPosY)):
			self.setY(newPosY)
		
	def gauche(self):
		newPosX = self.positionXY[0] - 1
		
		if (not self.collision(newPosX)):
			self.setX(newPosX)
		
	def droite(self):
		newPosX = self.positionXY[0] + 1
		
		if (not self.collision(newPosX)):
			self.setX(newPosX)
		
	def setX(self,val):
		self.positionXY[0] = val
		
	def setY(self,val):
		self.positionXY[1] = val
	
	def getX(self):
		return self.positionXY[0]
		
	def getY(self):
		return self.positionXY[1]
		
	def getXY(self):
		return [self.getX() , self.getY()]
		
	def getVal(self):
		return self.grille[self.getY()][self.getX()]
		
	def getEtat(self):
		
		if (self.getVal() != 1):
			return "Neutre"
		else:
			return "Sortie"
		
	
	def deplacement(self,wasd):
		
		if (wasd == 'w'):
			self.bas()
		elif (wasd == 'a'):
			self.gauche()
		elif (wasd == 's'):
			self.haut()
		elif (wasd == 'd'):
			self.droite()
		else:
			return "Erreur, mauvaise commande"
		
		return self.getEtat()
		
