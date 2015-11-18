using UnityEngine;
using System.Collections;

public class Targeting : MonoBehaviour {

//Not Run-able ATM concept

	float[] TargetManager (int x, int y){  //input xy distance from launch
		float theta = atand((2*y)/(x/2))); // Angle to theoretical arc peak so projectivle has -vel. when hitting taget // ERROR-whats arc tan?
		if (theta = 0){
			theta = .0000000001; // Needs to be divided by later can't be 0 w/o error // ERROR-curently a hotfix
		}
		float xVi = sqrt((G*x)/(sin(2*theta))); // Initial Velocity in x-axis // ERROR-sqrt & sin functions in c#? replace G with game gravity constant
		float yVi = sqrt((2*G*y)/(sin(theta)^2)); // Initial Velocity in y-axis
		float totalVi = sqrt(xVi^2 + yVi^2); // Total Velocity along theta
		return {totalVi, theta};
		/* // If needed... without physics engine; time independent
		x = xV + x; // Calculates next position x-axis constant vel. can change if (wind) applied like gravity
		xV = xVi + someForce;
		y = yV + y;
		yV = yVi - G;
		
		object(x,y); // Where object would now be
		*/
	}

