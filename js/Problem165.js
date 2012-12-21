/*
A segment is uniquely defined by its two endpoints.
By considering two line segments in plane geometry there are three possibilities:
the segments have zero points, one point, or infinitely many points in common.

Moreover when two segments have exactly one point in common it might be the case that that common point is an endpoint of either one of the segments or of both. If a common point of two segments is not an endpoint of either of the segments it is an interior point of both segments.
We will call a common point T of two segments L1 and L2 a true intersection point of L1 and L2 if T is the only common point of L1 and L2 and T is an interior point of both segments.

Consider the three segments L1, L2, and L3:

L1: (27, 44) to (12, 32)
L2: (46, 53) to (17, 62)
L3: (46, 70) to (22, 40)

It can be verified that line segments L2 and L3 have a true intersection point. We note that as the one of the end points of L3: (22,40) lies on L1 this is not considered to be a true point of intersection. L1 and L2 have no common point. So among the three line segments, we find one true intersection point.

Now let us do the same for 5000 line segments. To this end, we generate 20000 numbers using the so-called "Blum Blum Shub" pseudo-random number generator.

s[0] = 290797

s[n+1] = s[n]*s[n] (modulo 50515093)

t[n] = s[n] (modulo 500)

To create each line segment, we use four consecutive numbers tn. That is, the first line segment is given by:

(t[1], t[2]) to (t[3], t[4])

The first four numbers computed according to the above generator should be: 27, 144, 12 and 232. The first segment would thus be (27,144) to (12,232).

How many distinct true intersection points are found among the 5000 line segments?
*/

function Problem165(){
	var p=[];
	{
		var t=[];
		var s=290797;
		t[0]=0;
		for(var i=1;i<=2e2;i++){
			s=(s*s)%50515093;
			t[i]=s%500;
		}
		for(var i=0;i<5000;i++){
			p[i]={x1:t[4*i+1],y1:t[4*i+2],x2:t[4*i+3],y2:t[4*i+4]};
		}
	}

	var c=0;
	for(var i=0;i<5000;i++){
		var m1=(p[i].y2-p[i].y1)/(p[i].x2-p[i].x1);
		var b1=p[i].y1-m1*p[i].x1;
		for(var j=i+1;j<5000;j++){
			var m2=(p[j].y2-p[j].y1)/(p[j].x2-p[j].x1);
			var b2=p[j].y1-m2*p[j].x1;

			if(m1==m2){
				break;
			}

			var x=(b2-b1)/(m1-m2);
			var y=m1*x+b1;

			if(
				x>Math.min(p[i].x1,p[i].x2) &&
				x<Math.max(p[i].x1,p[i].x2) &&
				x>Math.min(p[j].x1,p[j].x2) &&
				x<Math.max(p[j].x1,p[j].x2)){
				console.log(x+","+y+" is on ("+p[i].x1+","+p[i].y1+") to ("+p[i].x2+","+p[i].y2+") and ("+p[j].x1+","+p[j].y1+") to ("+p[j].x2+","+p[j].y2+")");
				c++;
			}
		}
	}
	return c;
}

Problem165();