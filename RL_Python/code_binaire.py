#!/usr/bin/env python3
""" Module proposant la classe CodeBinaire et l'enumere Bit """

from enum import Enum, auto

class Bit(Enum):
	BIT_0 = auto()
	BIT_1 = auto()
	
	def __repr__(self):
		return "BIT_0" if self == Bit.BIT_0 else "BIT_1"

class CodeBinaire:
	
	def __init__(self,bit,*bits):
		
		self._bits = [bit,*bits]

	def ajouter(self, bit):
		self._bits.append(bit)
		
	def __len__(self):
		return len(self._bits)
		
	def __getitem__(self,indice_ou_slice):
		if isinstance (indice_ou_slice, int):
			return self._bits[indice_ou_slice]
		else:
			return CodeBinaire(*self._bits[indice_ou_slice])

	def __setitem__(self,indice_ou_slice,val):
		self._bits[indice_ou_slice] = val
		
	def __delitem__(self,indice):
		del(self._bits[indice])
		
	def __iter__(self):
		return iter(self._bits)
	
	def __eq__(self,other):
		return self._bits == other._bits
	
	def __repr__(self):
		return "CodeBinaire(" + ",".join([repr(b) for b in self._bits]) + ")"
		
	def __str__(self):
	    return "(" + ",".join(["0" if b == Bit.BIT_0 else "1" for b in self._bits]) + ")"
		
if __name__ == "__main__":
    def main():
        c=CodeBinaire(Bit.BIT_0, Bit.BIT_1)
        print(c)
        c.ajouter(Bit.BIT_0)
        print(c)
        print(len(c))
        print(c[1:3])
        print(c[0])
        c[0:2]=[Bit.BIT_1, Bit.BIT_1, Bit.BIT_0]
        print(c)
        c[0:2]=CodeBinaire(Bit.BIT_0, Bit.BIT_1)
        print(c)
        del(c[0])
        print(c)
        for b in c:
            print(b)
        print(c)
        print(c == CodeBinaire(Bit.BIT_1, Bit.BIT_0, Bit.BIT_0))
        print("-------------------------")
        print("repr")
        print(repr(c))
        print("str")
        print(str(c))
        
    main()  
    

    #ok_ko(Compteur.nb_occurrences, 2, CPT, 'a')
    #ok_ko(Compteur.elements, {'a', 'b', 'c', 'd'}, CPT)
    #ok_ko(Compteur.elements_moins_frequents, {'b', 'd'}, CPT)
    #ok_ko(Compteur.elements_plus_frequents, {'c'}, CPT)
    #ok_ko(Compteur.elements_par_nb_occurrences, {1: {'b', 'd'}, 2: {'a'}, 3: {'c'}}, CPT)
    #ok_ko(str, "{'a': 2, 'b': 1, 'c': 3, 'd': 1}", CPT)
    #ok_ko(repr, "Compteur({'a': 2, 'b': 1, 'c': 3, 'd': 1})", CPT)*/
