using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *The data are taken from Vectors Ephemeris Type https://ssd.jpl.nasa.gov/horizons.cgi#top
* 
 *   X    X-component of position vector (au)
 *   Y    Y-component of position vector (au)
 *   Z    Z-component of position vector (au)
 *   VX    X-component of velocity vector (au/day)                  
 *   VY    Y-component of velocity vector (au/day)                  
 *   VZ    Z-component of velocity vector (au/day)
 *
 *  axial tilt "angle" is expressed as rad
 *
 * 2459310.500000000 = A.D. 2021-Apr-06 00:00:00.0000 TDB
 * Time span: Start=2021-04-06, Stop=2021-04-07, Step=1 d
 */
/*
 * the components of the Vector3
 * should be converted from Astronomical units to metric SI system
 * https://en.wikipedia.org/wiki/Astronomical_unit
 * 1 AU = 1.495978707×10^11
 */

public class AUConversionHelper
{

 public Vector3 ConvertPositionToSI(Vector3 v)
 {
  Vector3 tmp = v * (1.495978707E+11f);
  return tmp;
 }

 public Vector3 ConvertVelocityToSI(Vector3 v)
 {
  Vector3 tmp = v * (1.495978707E+11f / 86400);
  return tmp;
 }
}

public class Sun
{
 public Vector3 initialPosition =
  new Vector3(-7.268739268017502E-03f, 5.413586843531350E-03f, 1.254915100830731E-04f);

 public Vector3 initialVelocity =
  new Vector3(-6.117689759081081E-06f, -6.647020557484176E-06f, 1.986938144979858E-07f);
 
 public  float mass = 1.988544E+30f;

 public  float angle = 0.1265364f;
 
 public  float rotationRate = 2.9028219148604441e-6f;

 public  float scale = 140;

}

public class Mercury
{
 public Vector3 initialPosition =
  new Vector3(1.4f, -2.032631574189585E-01f, -4.770078468513123E-02f);

 public Vector3 initialVelocity =
  new Vector3(9.329298657367415E-03f, 2.517410076060754E-02f, 1.201542950667524E-03f);
 
 public  float mass = 0.32E+24f;

 public  float angle = 5.235988e-5f;
 
 public  float rotationRate = 0.000001239932688f;

 public  float scale = 0.49f;
}

public class Venus
{
 public Vector3 initialPosition =
  new Vector3(3.282134370403665E-01f, -2.032631574189585E-01f, -4.770078468513123E-02f);

 public Vector3 initialVelocity =
  new Vector3(9.329298657367415E-03f, 2.517410076060754E-02f, 1.201542950667524E-03f);
 
 public  float mass = 4.88e+24f;

 public  float angle = 0.04607669f;
 
 public  float rotationRate = -0.000000299242049f;
 
 public  float scale = 1.2f;
}

public class Earth
{
 public Vector3 initialPosition =
  new Vector3(9.685532877791146E-01f, -2.724935310383544E-01f, 1.436975138144710E-04f);

 public Vector3 initialVelocity =
  new Vector3(4.486063262293801E-03f,  4.486063262293801E-03f,  1.376033535421714E-06f);

 public  float mass = 5.97219E+24f;

 public  float angle = 0.40910518f;
 
 public  float rotationRate = 7.292115e-5f;
 
 public  float scale = 1.27f;
}

public class Moon
{
 public Vector3 initialPosition =
  new Vector3(-9.670584586788202E-01f, -2.745719463850099E-01f, -4.000750239514857E-05f);

 public Vector3 initialVelocity =
  new Vector3(4.979661618964132E-03f,  -1.628191448592499E-02f,  -3.189027814180462E-05f);

 public  float mass = 7.35e+22f;

 public  float angle = 0.116588f;
 
 public  float rotationRate = 2.6616995e-6f;
 
 public  float scale = 0.34f;
}

public class Mars
{
 public Vector3 initialPosition =
  new Vector3(-6.288276221827235E-01f, 1.500676895809539E+00f, 4.670742709349911E-02f);

 public Vector3 initialVelocity =
  new Vector3(-1.239908227332102E-02f,  -4.189294437942442E-03f,  2.165537790655048E-04f);

 public  float mass = 0.64e+24f;

 public  float angle =  0.43964844f;
 
 public  float rotationRate = 0.00007094834358f;
 
 public  float scale = 0.7f;
}

public class Jupiter
{
 public Vector3 initialPosition =
  new Vector3(3.568559932789492E+00f, -3.580646845719153E+00f, -6.498341774832760E-02f);

 public Vector3 initialVelocity =
  new Vector3(5.252430584888574E-03f,  5.683608561516795E-03f,  -1.410614567891667E-04f);

 public  float mass = 19.00e+26f;

 public  float angle =  0.05462881f;
 
 public  float rotationRate = 1.75865e-4f;
 
 public  float scale = 14.3f;
}

public class Saturn
{
 public Vector3 initialPosition =
  new Vector3(5.889352764295609E+00f, -8.035045710599322E+00f, -9.475963866030872E-02f);

 public Vector3 initialVelocity =
  new Vector3(4.188601273844896E-03f,  3.285451935426094E-03f,  -2.242091209389519E-04f);

 public  float mass = 5.68e+26f;

 public  float angle =  0.46652651f;
 
 public  float rotationRate = 1.63785e-4f;
 
 public  float scale = 12f;
}

public class Uranus
{
 public Vector3 initialPosition =
  new Vector3(1.510236655036207E+01f, 1.273800343060280E+01f, -1.483434937072435E-01f);

 public Vector3 initialVelocity =
  new Vector3(-2.564514036977496E-03f,  2.823216663143912E-03f,  4.377520862383356E-05f);

 public  float mass = 0.87e+26f;

 public  float angle = 1.4351842f;
 
 public  float rotationRate = -0.0001014726309f;
 
 public  float scale = 5f;
}

public class Neptune
{
 public Vector3 initialPosition =
  new Vector3(2.950252284452605E+01f, -4.930162272600606E+00f, -5.783882930560084E-01f);

 public Vector3 initialVelocity =
  new Vector3(4.966249971050125E-04f,  3.115235127426033E-03f,  -7.524240418174830E-05f);

 public  float mass = 1.03e+26f;

 public  float angle = 0.494277244f;
 
 public  float rotationRate = 1.083e-4f;
 
 public  float scale = 5f;
}
