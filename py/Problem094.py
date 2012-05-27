import math

sum = 0

for i in xrange(1,333333334):
	for b in range(i-1,i+1+1,2):
		if i%100000==0:
			print i
		# h = math.sqrt(i**2-(b/2)**2)
		# a = (b/2)*h
		# if a%1 == 0:
			# sum += i+i+b
			# print sum

print sum