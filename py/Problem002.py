a=0
b=0
c=1
s=0

while c<4000000:
	a=b
	b=c
	c=a+b

	if c%2 == 0:
		s+=c

print s
