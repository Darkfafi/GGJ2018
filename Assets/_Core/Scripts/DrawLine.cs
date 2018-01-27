using UnityEngine;
using System.Collections;

public class DrawLine : MonoBehaviour
{
	public static DrawLine Instance;

	// When added to an object, draws colored rays from the
	// transform position.
	public int lineCount = 100;
	public float radius = 3.0f;
	
	static Material lineMaterial;
	/*
	float[] x;// = Random.Range (-100, 100);
	float[] y;// = Random.Range (-100, 100);
	float[] z;// = Random.Range (-100, 100);
	*/

	void Awake ()
	{
		if (Instance != null) {
			Debug.LogWarning ("DrawLine already exists");
		} else {
			Instance = this;
		}
	}

	void Start ()
	{
/*
		for (int i =0; i< 20; ++i) {
			x [i] = Random.Range (-100, 100);
			y [i] = Random.Range (-100, 100);
			z [i] = Random.Range (-100, 100);
		}
*/
	}

	void Update ()
	{
		DrawSpaceDust (10);
	}


	static void CreateLineMaterial ()
	{
		if (!lineMaterial) {
			// Unity has a built-in shader that is useful for drawing
			// simple colored things.
			var shader = Shader.Find ("Hidden/Internal-Colored");
			lineMaterial = new Material (shader);
			lineMaterial.hideFlags = HideFlags.HideAndDontSave;
			// Turn on alpha blending
			lineMaterial.SetInt ("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
			lineMaterial.SetInt ("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
			// Turn backface culling off
			lineMaterial.SetInt ("_Cull", (int)UnityEngine.Rendering.CullMode.Off);
			// Turn off depth writes
			lineMaterial.SetInt ("_ZWrite", 0);
		}
	}
	


	void DrawSpaceDust (int amount)
	{
		CreateLineMaterial ();
		lineMaterial.SetPass (0);
		
		GL.PushMatrix ();
		//	GL.MultMatrix (transform.localToWorldMatrix);
		GL.Begin (GL.LINES);
		GL.Color (Color.white);

		for (int i =0; i < amount; ++i) {
		
			//		GL.Vertex3 (x [i], y [i], z [i]);
			//		GL.Vertex3 (x [i] + .1f, y [i] + .1f, z [i] + .1f);
		}
		//GL.Clear (true, true, Color.black);
		GL.End ();
		GL.PopMatrix ();

	}


	//test en debug etc
	void DrawLInesAllDirection ()
	{
		CreateLineMaterial ();
		// Apply the line material
		lineMaterial.SetPass (0);
		
		GL.PushMatrix ();
		// Set transformation matrix for drawing to
		// match our transform
		GL.MultMatrix (transform.localToWorldMatrix);
		
		// Draw lines
		GL.Begin (GL.LINES);
		for (int i = 0; i < lineCount; ++i) {
			float a = i / (float)lineCount;
			float angle = a * Mathf.PI * 2;
			// Vertex colors change from red to green
			GL.Color (new Color (a, 1 - a, 0, 0.8F));
			// One vertex at transform position
			GL.Vertex3 (0, 0, 0);
			// Another vertex at edge of circle
			GL.Vertex3 (Mathf.Cos (angle) * radius, Mathf.Sin (angle) * radius, 0);
		}
		GL.End ();
		GL.PopMatrix ();
	}

	public void DrawSimpleLine (Vector3 start, Vector3 end, Color c)
	{
		CreateLineMaterial ();
		lineMaterial.SetPass (0);
		
		GL.PushMatrix ();
		//	GL.MultMatrix (transform.localToWorldMatrix);
		GL.Begin (GL.LINES);
		GL.Color (c);
		GL.Vertex3 (start.x, start.y, start.z);
		GL.Vertex3 (end.x, end.y, end.z);
		GL.End ();
		GL.PopMatrix ();
	}

	public void DrawGrid (float grid, int x, int z, float step, Color c, Vector3 offset)
	{
		for (int i = 0; i < x; ++i) {
			DrawSimpleLine (new Vector3 (0 + i * step, 0, 0), new Vector3 (0 + i * step, 0, grid), c);
			DrawSimpleLine (new Vector3 (0, 0, 0 + i * step), new Vector3 (grid, 0, 0 + i * step), c);

			
		}
	}


	public void DrawCircle (int subdivisions, Vector3 origin, float radius, Color c)
	{
		Vector3 pFirst = new Vector3 ();
		Vector3 pSecond = new Vector3 ();	// points to connect
		
		float x, y, pi2 = Mathf.PI * 2;	// tmp helper variables
		
		for (int i=0; i<=subdivisions; i++) {
			
			x = Mathf.Cos ((pi2 * i) / subdivisions) * radius;
			
			y = Mathf.Sin ((pi2 * i) / subdivisions) * radius;
			
			pSecond = new Vector3 (x, 0, y);
			
			pSecond += origin;
			
			if (i > 0) {
				
				DrawSimpleLine (pFirst, pSecond, c);
				
			}
			
			pFirst = pSecond;
		}
	}

	public void DrawSphere (int subdivisions, Vector3 origin, float radius)
	{
		Vector3 pFirst = new Vector3 ();
		Vector3 pSecond = new Vector3 ();	// points to connect
		
		float x, y, pi2 = Mathf.PI * 2;	// tmp helper variables
		
		for (int i=0; i<=subdivisions; i++) {
			
			x = Mathf.Cos ((pi2 * i) / subdivisions) * radius;
			
			y = Mathf.Sin ((pi2 * i) / subdivisions) * radius;
			
			pSecond = new Vector3 (x, 0, y);
			
			pSecond += origin;
			
			if (i > 0) {
				
				DrawSimpleLine (pFirst, pSecond, Color.red);
				
			}
			
			pFirst = pSecond;
		}

		for (int i=0; i<=subdivisions; i++) {
			
			x = Mathf.Cos ((pi2 * i) / subdivisions) * radius;
			
			y = Mathf.Sin ((pi2 * i) / subdivisions) * radius;
			
			pSecond = new Vector3 (0, x, y);
			
			pSecond += origin;
			
			if (i > 0) {
				
				DrawSimpleLine (pFirst, pSecond, Color.red);
				
			}
			
			pFirst = pSecond;
		}


		for (int i=0; i<=subdivisions; i++) {
			
			x = Mathf.Cos ((pi2 * i) / subdivisions) * radius;
			
			y = Mathf.Sin ((pi2 * i) / subdivisions) * radius;
			
			pSecond = new Vector3 (x, y, 0);
			
			pSecond += origin;
			
			if (i > 0) {
				
				DrawSimpleLine (pFirst, pSecond, Color.red);
				
			}
			
			pFirst = pSecond;
		}
	}



	void DrawBall (int sides, Color c)
	{
		//glColor3f(R, G, B);
		GL.Color (c);

		//	glEnable(GL_TEXTURE_2D);
		//	glBindTexture(GL_TEXTURE_2D, texture[3]);
		
		
		//	float theta1 = 0, theta2 = 0, theta3 = 0;
		
		//	float ex = 0, px = 0, cx = xcoord;
		//	float ey = 0, py = 0, cy = ycoord;
		//	float ez = 0, pz = 0, cz = 0, r = radius;
		
		for (int j = 0; j < sides / 2; j++) {
			//		theta1 = j * 2 * Mathf.PI / sides - Mathf.PI / 2;
			//		theta2 = (j + 1) * 2 * Mathf.PI / sides - Mathf.PI / 2;
			/*
			glBegin(GL_QUAD_STRIP);
			{
				for (int i = 0; i <= sides; i++)
				{
					theta3 = i * TWOPI / sides;
					
					ex = fcos(theta1) * fcos(theta3);
					ey = fsin(theta1);
					ez = fcos(theta1) * fsin(theta3);
					px = cx + r * ex;
					py = cy + r * ey;
					pz = cz + r * ez;
					
					glNormal3f(ex,ey,ez);
					glTexCoord2f(i/(float)sides,2*j/(float)sides);
					glVertex3f(px, py, pz);
					
					ex = fcos(theta2) * fcos(theta3);
					ey = fsin(theta2);
					ez = fcos(theta2) * fsin(theta3);
					px = cx + r * ex;
					py = cy + r * ey;
					pz = cz + r * ez;	
					
					glNormal3f(ex,ey,ez);
					glTexCoord2f(i/(float)sides,2*(j+1)/(float)sides);
					glVertex3f(px, py, pz);
				}
			}
			glEnd();
		}
		*/
		
			//	return *this;
		}

		/*
	public Material mat;
	private Vector3 startVertex;
	private Vector3 mousePos;
	void Update ()
	{
		mousePos = Input.mousePosition;
		if (Input.GetKeyDown (KeyCode.Space))
			startVertex = new Vector3 (mousePos.x / Screen.width, mousePos.y / Screen.height, 0);
		
	}
	void OnPostRender ()
	{
		if (!mat) {
			Debug.LogError ("Please Assign a material on the inspector");
			return;
		}

		GL.PushMatrix ();
		mat.SetPass (0);

		//GL.LoadOrtho ();
		GL.Begin (GL.LINES);
		GL.Color (Color.red);
		GL.Vertex (startVertex);
		GL.Vertex (new Vector3 (mousePos.x / Screen.width, mousePos.y / Screen.height, 0));
		GL.End ();
		GL.PopMatrix ();

		
	}
	void Example ()
	{
		startVertex = new Vector3 (0, 0, 0);
	}
	*/
	}
}
