using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace lab6
{
    public enum LightType {lAmbient, lPoint, lDirectional };

    public partial class Form1 : Form
    {
        Graphics g_fake_camera;
        List<Polyhedron> scene = null;
        List<Light> lights = null;
        Camera camera = null;
        int Viewport_w = 0;
        int Viewport_h = 0;
        int projection_plane_d = 0;
        int inf = 1000000;
        float eps = 1E-3f;
        float rec_depth = 1;
        Color background_color = Color.Black;
        float camera_angle = 0;
        public Form1()
        {
            InitializeComponent();
           
            pictureBox3.Image = new Bitmap(pictureBox3.Width, pictureBox3.Height);
            g_fake_camera = Graphics.FromImage(pictureBox3.Image);
            g_fake_camera.TranslateTransform(pictureBox3.ClientSize.Width / 2, pictureBox3.ClientSize.Height / 2);
            g_fake_camera.ScaleTransform(1, -1);
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            scene = new List<Polyhedron>();
            lights = new List<Light>();
            create_scene();
            create_lights();

            show_scene1();
        }

        private Color increase(float k, Color c)
        {
            int a = c.A;
            int r = Math.Min(255, Math.Max(0, (int)(c.R * k + 0.5)));

            int g = Math.Min(255, Math.Max(0, (int)(c.G * k + 0.5)));

            int b = Math.Min(255, Math.Max(0, (int)(c.B * k + 0.5)));

            return Color.FromArgb(a, r, g, b);
        }

        private Color increase(Point3d k, Color c)
        {
            int a = c.A;
            int r = Math.Min(255, Math.Max(0, (int)(c.R * k.X + 0.5)));

            int g = Math.Min(255, Math.Max(0, (int)(c.G * k.Y + 0.5)));

            int b = Math.Min(255, Math.Max(0, (int)(c.B * k.Z + 0.5)));

            return Color.FromArgb(a, r, g, b);
        }

        private Color sum(Color c1, Color c2)
        {
            //what alpha? doing this later
            int a = c1.A;
            int r = Math.Max(0, Math.Min(255, c1.R + c2.R));
            int g = Math.Max(0, Math.Min(255, c1.G + c2.G));
            int b = Math.Max(0, Math.Min(255, c1.B + c2.B));

            return Color.FromArgb(a, r, g, b);
        }


        private float dot(Point3d v1, Point3d v2)
        {
            return v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z;
        }

        private float length(Point3d vec)
        {
            return (float)Math.Sqrt(dot(vec, vec));
        }

        private Point3d multiply(float k, Point3d vec)
        {
            return new Point3d(k * vec.X, k * vec.Y, k * vec.Z);
        }

        private Point3d add(Point3d vec1, Point3d vec2)
        {
            return new Point3d(vec1.X + vec2.X, vec1.Y + vec2.Y, vec1.Z + vec2.Z);
        }

        private Point3d sub(Point3d vec1, Point3d vec2)
        {
            return new Point3d(vec1.X - vec2.X, vec1.Y - vec2.Y, vec1.Z - vec2.Z);
        }

        //отражает луч R относительно нормали N
        private Point3d ReflectRay(Point3d R, Point3d N)
        {
            return sub(multiply(2 * dot(R, N), N), R);
        }

        private void create_scene()
        {
            Viewport_w = 1;
            Viewport_h = 1;
            projection_plane_d = 1;
            rec_depth = 3;
            create_camera(new Point3d(0, 3, -15));

            if (scene != null)
                scene.Clear();

            var figure = new Polyhedron();
            figure.make_sphere(new Point3d(0, 2, 3), 1);
            figure.color = Color.Red;
            figure.specular = 500;
            figure.reflective = 0.2f;
            figure.comment = "шар";
            scene.Add(figure);
            sceneBox.Items.Add("SPHERE0");

            figure = new Polyhedron();
            figure.make_sphere(new Point3d(2, 0, 4), 1);
            figure.color = Color.Yellow;
            figure.specular = 500;
            figure.reflective = 0.3f;
            figure.transparent = 0.9f;
            figure.comment = "еще шар";
            scene.Add(figure);
            sceneBox.Items.Add("SPHERE1");

            figure = new Polyhedron();
            figure.make_sphere(new Point3d(-2, 0, 4), 1);
            figure.color = Color.Green;
            figure.specular = 500;
            figure.reflective = 0.9f;
            figure.comment = "и снова шар";
            scene.Add(figure);
            sceneBox.Items.Add("SPHERE2");

           figure = new Polyhedron();
            figure.make_hexahedron(1f);
            figure.translate(0, 0, 3);
            figure.color = Color.YellowGreen;
            figure.specular = 500;
            figure.reflective = 0.1f;
            figure.transparent = 0.5f;
            figure.comment = "";
            figure.find_normals();
            scene.Add(figure);
            sceneBox.Items.Add("CUBE0");

            figure = new Polyhedron();
            figure.make_hexahedron(2f);
            figure.translate(-8, 1, 0);
            figure.color = Color.Pink;
            figure.specular = 500;
            figure.reflective = 0.4f;
            figure.transparent = 0f;
            figure.comment = "";
            figure.find_normals();
            scene.Add(figure);
            sceneBox.Items.Add("CUBE1");

            figure = new Polyhedron();
            figure.make_hexahedron(1f);
            figure.rotate(45, Axis.AXIS_Y);
            figure.translate(-8, 4f, 0);
            figure.color = Color.PowderBlue;
            figure.specular = 500;
            figure.reflective = 0.4f;
            figure.transparent = 0f;
            figure.comment = "";
            figure.find_normals();
            scene.Add(figure);
            sceneBox.Items.Add("CUBE2");

            figure = new Polyhedron();
            figure.make_hexahedron(0.5f);
            figure.translate(-8, 5.5f, 0);
            figure.color = Color.YellowGreen;
            figure.specular = 500;
            figure.reflective = 0.1f;
            figure.transparent = 0f;
            figure.comment = "";
            figure.find_normals();
            scene.Add(figure);
            sceneBox.Items.Add("CUBE3");

            Face f = new Face(new List<Point3d>() { new Point3d(-10, -1, 10), new Point3d(-10,10,10), new Point3d(10, 10, 10), new Point3d(10, -1,10) });
            figure = new Polyhedron(new List<Face>() { f });
            figure.Faces[0].Normal = new List<float>() { 0, 0, 1 };
            figure.color = Color.White;
            figure.specular = 0;
            figure.reflective = 0f;
            figure.comment = "back";
            scene.Add(figure);
            sceneBox.Items.Add("WALL0");

            f = new Face(new List<Point3d>() { new Point3d(-10, -1, -10), new Point3d(-10, -1, 10), new Point3d(10, -1, 10), new Point3d(10, -1, -10) });
            figure = new Polyhedron(new List<Face>() { f });
            figure.Faces[0].Normal = new List<float>() { 0, -1, 0 };
            figure.color = Color.White;
            figure.specular = 0;
            figure.reflective = 0f;
            figure.comment = "down";
            figure.color = Color.LightGray;
            scene.Add(figure);
            sceneBox.Items.Add("WALL1");

            f = new Face(new List<Point3d>() { new Point3d(-10,10,-10), new Point3d(-10, 10, 10), new Point3d(10, 10, 10), new Point3d(10, 10, -10) });
            figure = new Polyhedron(new List<Face>() { f });
            figure.Faces[0].Normal = new List<float>() { 0, 1,0 };
            figure.color = Color.White;
            figure.specular = 0;
            figure.reflective = 0f;
            figure.comment = "top";
            figure.color = Color.Red;
            scene.Add(figure);
            sceneBox.Items.Add("WALL2");

            f = new Face(new List<Point3d>() { new Point3d(-10, -1, -10), new Point3d(-10, 10, -10), new Point3d(-10, 10, 10), new Point3d(-10, -1, 10) });
            figure = new Polyhedron(new List<Face>() { f });
            figure.Faces[0].Normal = new List<float>() { -1, 0, 0 };
            figure.color = Color.White;
            figure.specular = 0;
            figure.reflective = 0f;
            figure.comment = "left";
            figure.color = Color.Green;
            scene.Add(figure);
            sceneBox.Items.Add("WALL3");

            f = new Face(new List<Point3d>() { new Point3d(10, -1, -10), new Point3d(10, 10, -10), new Point3d(10, 10, 10), new Point3d(10, -1, 10) });
            figure = new Polyhedron(new List<Face>() { f });
            figure.Faces[0].Normal = new List<float>() { 1, 0, 0 };
            figure.color = Color.White;
            figure.specular = 0;
            figure.reflective = 0f;
            figure.comment = "right";
            figure.color = Color.Ivory;
            scene.Add(figure);
            sceneBox.Items.Add("WALL4");

            f = new Face(new List<Point3d>() { new Point3d(-10, -1, -10), new Point3d(-10, 10, -10), new Point3d(10, 10, -10), new Point3d(10, -1, -10) });
            figure = new Polyhedron(new List<Face>() { f });
            figure.Faces[0].Normal = new List<float>() { 0, 0, -1 };
            figure.color = Color.White;
            figure.specular = 0;
            figure.reflective = 0f;
            figure.comment = "front";
            scene.Add(figure);
            sceneBox.Items.Add("WALL5");

            sceneBox.SelectedIndex = 0;

        }

        private void create_lights()
        {
            if (lights != null)
            {
                lights.Clear();
                lightBox.Items.Clear();
            }

            lights.Add(new Light(LightType.lAmbient, 0.2f, new Point3d(0, 0, 0)));
            lights[0].enable();
            lightBox.Items.Add("LIGHT0");

            lights.Add(new Light(LightType.lPoint, 0.2f, new Point3d(0, 9, 0)));
            lights[1].enable();
            lightBox.Items.Add("LIGHT1");
            
            lights.Add(new Light(LightType.lPoint, 0.6f, new Point3d(-9, 9, -9)));
            lights[2].enable();
            lightBox.Items.Add("LIGHT2");

            lights.Add(new Light(LightType.lPoint, 0.6f, new Point3d(-9, 9, 9)));            
            lightBox.Items.Add("LIGHT3");

            lights.Add(new Light(LightType.lPoint, 0.6f, new Point3d(9, 9, 9)));
            lights[4].set_color(Color.Red);
            lightBox.Items.Add("LIGHT4");

            lights.Add(new Light(LightType.lPoint, 0.6f, new Point3d(9, 9, -9)));
            lightBox.Items.Add("LIGHT5");

            lights.Add(new Light(LightType.lDirectional, 0.2f, new Point3d(1, 4, 0)));
            lightBox.Items.Add("LIGHT6");

            lightBox.SelectedIndex = 1;
        }
        
        private Point3d CanvasToViewport(int x, int y, float width, float height)
        {
            //distance from camera to viewport
            float X = (float)x * Viewport_w / width;
            float Y = (float)y * Viewport_h / height;
            return new Point3d(X, Y, projection_plane_d);
        }

        private void ClosestIntersection(Point3d camera, Point3d D, float t_min, float t_max, ref Polyhedron closest, ref float closest_t, ref Point3d norm)
        {
            closest_t = inf;
            closest = null;
            norm = null;
            foreach (var pol in scene)
            {
                if (pol.is_sphere)
                {
                    PointF t = IntersectRaySphere(camera, D, pol);
                    //t.x - первый корень, t.y - второй
                    if (t.X < closest_t && t_min < t.X && t.X < t_max)
                    {
                        closest_t = t.X;
                        closest = pol;
                    }
                    if (t.Y < closest_t && t_min < t.Y && t.Y < t_max)
                    {
                        closest_t = t.Y;
                        closest = pol;
                    }
                }
                else
                {
                    Point3d norm_2 = null;
                    Point3d point_2 = null;
                    float t = intersectRay(camera, D, pol, ref norm_2);
                    if (t < closest_t && t_min < t && t < t_max)
                    {
                        closest_t = t;
                        closest = pol;
                        norm = norm_2;
                    }
                }
            }
            if (closest != null && closest.is_sphere)
            {
                var point = add(camera, multiply(closest_t, D));
                norm = sub(point, closest.Center);
            }
        }

        private Color TraceRay(Point3d camera, Point3d D, float t_min, float t_max, float depth, int step)
        {
            float closest_t = inf;
            Polyhedron closest = null;
            Point3d normal = null;
            Point3d point = null;
            ClosestIntersection(camera, D, t_min, t_max, ref closest, ref closest_t, ref normal);
            
            //если луч уходит вникуда
            if (closest == null)
                return background_color;
            
            //привели к единичной
            normal = multiply(1.0f / length(normal), normal);

            point = add(camera, multiply(closest_t, D));
            //высчитываем освещенность
            var light_k = ComputeLighting(point, normal, multiply(-1, D), closest.specular);
            Color local = increase(light_k, closest.color);

            //добавляем отражения
            if (step>7 || depth <= eps)
                return local;

            var r = ReflectRay(multiply(-1, D), normal);
            var refl_color = TraceRay(point, r, eps, inf, depth*closest.reflective, step+1);
            //сумма полученного цвета и пришедшего из отраженного луча
            Color reflected = sum(increase(1 - closest.reflective, local), increase(closest.reflective, refl_color));

            if (closest.transparent <= 0)
            return increase(depth,reflected);

            //добавить прозрачность
            //допустим, что луч не преломляется
            var tr_color = TraceRay(point, D, eps, inf, depth * closest.transparent, step+1);
            Color transp = sum(increase(1-closest.transparent, reflected), increase(closest.transparent, tr_color));

            return increase(depth,transp);
        }

        private Point3d ComputeLighting(Point3d point, Point3d normal, Point3d view, float specular)
        {
            Point3d intensity = new Point3d(0,0,0);
            float length_n = length(normal);  // Should be 1.0, but just in case...
            float length_v = length(view);
            float t_max = 0 ;

            for (int i = 0; i < lights.Count; ++i)
            {
                Light light = lights[i];
                if (!light.enabled)
                    continue;
                if (light.type == LightType.lAmbient)
                {
                    intensity.X += light.r_intensity;
                    intensity.Y += light.g_intensity;
                    intensity.Z += light.b_intensity;
                }
                else
                {
                    Point3d vec_l;
                    if (light.type == LightType.lPoint)
                    {
                        vec_l = sub(light.position, point);
                        t_max = 1f;
                    }
                    else
                    {  // Light.DIRECTIONAL
                        vec_l = light.position;
                        t_max = inf;
                    }

                    //is shadow
                    Polyhedron blocker = null;
                    float closest_t = 0f ;
                    Point3d norm = null;
                    Point3d point_t = null;
                    ClosestIntersection(point, vec_l, eps, t_max, ref blocker, ref closest_t, ref norm);
                    float tr = 1;
                    if (blocker != null)
                        //tr = blocker.transparent;
                        continue;
                    //diffuse
                    var n_dot_l = dot(normal, vec_l);
                    if (n_dot_l > 0)
                    {
                        //intensity += light_int * n_dot_l / (length_n * length(vec_l));
                        intensity.X += tr*light.r_intensity * n_dot_l / (length_n * length(vec_l));
                        intensity.Y += tr * light.g_intensity * n_dot_l / (length_n * length(vec_l));
                        intensity.Z += tr * light.b_intensity * n_dot_l / (length_n * length(vec_l));
                    }

                    //specular
                    if (specular > 0)
                    {
                        var vec_r = ReflectRay(vec_l, normal);
                        var r_dot_v = dot(vec_r, view);
                        if (r_dot_v > 0)
                        {
                            //intensity += light_int * (float)Math.Pow(r_dot_v / (length(vec_r) * length_v), specular);
                            intensity.X += tr *  light.r_intensity * (float)Math.Pow(r_dot_v / (length(vec_r) * length_v), specular);
                            intensity.Y += tr * light.g_intensity * (float)Math.Pow(r_dot_v / (length(vec_r) * length_v), specular);
                            intensity.Z += tr * light.b_intensity * (float)Math.Pow(r_dot_v / (length(vec_r) * length_v), specular);
                        }
                    }
                }
            }
            return intensity;
        }

        private float intersectRay(Point3d camera, Point3d D, Polyhedron pol, ref Point3d norm)
        {
            float res = inf;
            norm = null;
            for (int i = 0; i < pol.Faces.Count; ++i)
            {
                //pol.Faces[i].find_normal(pol.Center, new Edge(camera, camera));
                var n = pol.Faces[i].Normal;
                Point3d normal = new Point3d(n[0], n[1], n[2]);
                multiply(1f / length(normal), normal);

                var d_n = dot(D, normal);
                if (d_n < eps)
                    continue;

                var d = dot(sub(pol.Faces[i].Center, camera), normal) / d_n;

                if (d < 0)
                    continue;
                var point = add(camera, multiply(d, D));
                if (res > d && pol.Faces[i].inside(point))
                {
                    res = d;
                    norm = multiply(-1, normal);
                }
            }
            return res;
        }

        private PointF IntersectRaySphere(Point3d camera, Point3d D, Polyhedron sphere)
        {
            PointF res = new Point(inf, inf);
            float r = sphere.rad;
            //направление из центра в камеру?
            Point3d OC = sub(camera, sphere.Center);

            float k1 = dot(D, D);
            float k2 = 2 * dot(OC, D);
            float k3 = dot(OC, OC) - r * r;

            float discriminant = k2 * k2 - 4 * k1 * k3;
            if (discriminant < 0) return res;

            double t1 = (-k2 + Math.Sqrt(discriminant)) / (2 * k1);
            double t2 = (-k2 - Math.Sqrt(discriminant)) / (2 * k1);
            res.X = (float)t1;
            res.Y = (float)t2;
            return res;
        }

        private void show_scene3()
        {
            //координаты холста от -width/2 до width/2, -height/2 до height/2
            //экранная координата
            //int sx = pictureBox3.Width / 2 + cx;
            //int sy = pictureBox3.Height / 2 - cy;
            Bitmap bmp = pictureBox3.Image as Bitmap;
            g_fake_camera.Clear(Color.White);
            for (int x = -pictureBox3.Width / 2; x < pictureBox3.Width / 2; ++x)
            {
                for (int y = -pictureBox3.Height / 2; y < pictureBox3.Height / 2; ++y)
                {
                    Point3d D = CanvasToViewport(x, y, pictureBox3.Width, pictureBox3.Height);
                    D.rotate(camera_angle, Axis.AXIS_Y);
                    Color c = TraceRay(camera.view.P1, D, 1, inf, 1, 0);
                    int bmpx = x + pictureBox3.Width / 2;
                    int bmpy = pictureBox3.Height / 2 - y - 1;

                    if (bmpx < 0 || bmpx >= pictureBox3.Width || bmpy < 0 || bmpy >= pictureBox3.Height)
                        continue;
                    bmp.SetPixel(bmpx, bmpy, c);
                }
                pictureBox3.Refresh();
            }
            pictureBox3.Refresh();
        }

        private void show_scene1()
        {
            //координаты холста от -width/2 до width/2, -height/2 до height/2
            //экранная координата
            //int sx = pictureBox3.Width / 2 + cx;
            //int sy = pictureBox3.Height / 2 - cy;
            Bitmap bmp = pictureBox1.Image as Bitmap;
            //g_fake_camera.Clear(Color.White);
            for (int x = -pictureBox1.Width / 2; x < pictureBox1.Width / 2; ++x)
            {
                for (int y = -pictureBox1.Height / 2; y < pictureBox1.Height / 2; ++y)
                {
                    Point3d D = CanvasToViewport(x, y, pictureBox1.Width, pictureBox1.Height);
                    D.rotate(camera_angle, Axis.AXIS_Y);
                    Color c = TraceRay(camera.view.P1, D, 1, inf, 1, 0);
                    int bmpx = x + pictureBox1.Width / 2;
                    int bmpy = pictureBox1.Height / 2 - y - 1;

                    if (bmpx < 0 || bmpx >= pictureBox1.Width || bmpy < 0 || bmpy >= pictureBox1.Height)
                        continue;
                    bmp.SetPixel(bmpx, bmpy, c);
                }
            }
            pictureBox1.Refresh();
        }

        private void button_exec_camera_Click(object sender, EventArgs e)
        {
            check_all_textboxes();
            // поворачиваем относительно нужной прямой
            if (rot_angle_camera.Text != "0")
            {
                //крутим относительно центра?
                //float old_x_camera = camera.view.P1.X,
                //    old_y_camera = camera.view.P1.X,
                //    old_z_camera = camera.view.P1.X;
                //camera.translate(-old_x_camera, -old_y_camera, -old_z_camera);

                double angle = double.Parse(rot_angle_camera.Text, CultureInfo.CurrentCulture);
                camera_angle += (float)angle;
                if (camera_angle > 360)
                    camera_angle -= 360;
                camera.rotate(angle, Axis.AXIS_Y);

                //camera.translate(old_x_camera, old_y_camera, old_z_camera);
            }


            camera_x.Text = ((int)camera.view.P1.X).ToString(CultureInfo.CurrentCulture);
            camera_y.Text = ((int)camera.view.P1.Y).ToString(CultureInfo.CurrentCulture);
            camera_z.Text = ((int)camera.view.P1.Z).ToString(CultureInfo.CurrentCulture);

            show_scene1();
        }

        private void create_camera(Point3d p)
        {
            camera = new Camera(p, pictureBox3.ClientSize.Width, pictureBox3.ClientSize.Height);
            camera_x.Text = ((int)camera.view.P1.X).ToString();
            camera_y.Text = ((int)camera.view.P1.Y).ToString();
            camera_z.Text = ((int)camera.view.P1.Z).ToString();
            
            camera.set_rot_line(Axis.AXIS_Y);
        }

        // контроль вводимых символов
        private void textBox_KeyPress_int(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == '-') && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }

        private void textBox_KeyPress_double(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == '.' || e.KeyChar == ',') && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }

        void check_all_textboxes()
        {
            foreach (var c in Controls)
            {
                if (c is TextBox)
                {
                    TextBox t = c as TextBox;
                    if (string.IsNullOrEmpty(t.Text))
                    {
                        if (t.Name == "scaling_x" || t.Name == "scaling_y" || t.Name == "scaling_z" || t.Name == "rot_line_x2" ||
                            t.Name == "rot_line_y2" || t.Name == "rot_line_z2")
                            t.Text = "1";
                        else t.Text = "0";
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            show_scene3();
        }

        private void show_light_info(int ind)
        {
            var light = lights[ind];
            label_light_type.Text = light.type.ToString();
            label_light_pos.Text = light.position.to_string();
            checkBox_light.Checked = light.enabled;
            label_light_color.BackColor = light.color;
        }

        private void lightBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            show_light_info(lightBox.SelectedIndex);
        }

        private void checkBox_light_CheckedChanged(object sender, EventArgs e)
        {
            lights[lightBox.SelectedIndex].enabled = checkBox_light.Checked;
            show_scene1();
        }

        private void label_light_color_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            var tmp_color = colorDialog1.Color;
            label_light_color.BackColor = tmp_color;
            lights[lightBox.SelectedIndex].set_color(tmp_color);
            show_scene1();
        }
        
        private void label_scene_color_Click(object sender, EventArgs e)
        {
            if (colorDialog2.ShowDialog() == DialogResult.Cancel)
                return;
            var tmp_color = colorDialog2.Color;
            label_scene_color.BackColor = tmp_color;
            scene[sceneBox.SelectedIndex].color = tmp_color;
            show_scene1();
        }

        private void show_scene_info(int ind)
        {
            var pol = scene[ind];
            label_scene_comment.Text = pol.comment;
            textBox_scene_spec.Text = pol.specular.ToString();
            textBox_scene_transp.Text = pol.transparent.ToString();
            textBox_scene_refl.Text = pol.reflective.ToString();
            label_scene_color.BackColor = pol.color;
        }

        private void sceneBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            show_scene_info(sceneBox.SelectedIndex);
        }


        private void textBox_scene_spec_TextChanged(object sender, EventArgs e)
        {
            if (textBox_scene_spec.Text == "")
                textBox_scene_spec.Text = "0";
            var i = int.Parse(textBox_scene_spec.Text);
            scene[sceneBox.SelectedIndex].specular = Math.Min(1000, Math.Max(i, 0));
            textBox_scene_spec.Text = scene[sceneBox.SelectedIndex].specular.ToString();
            show_scene1();
        }

        private void textBox_scene_refl_TextChanged(object sender, EventArgs e)
        {
            if (textBox_scene_refl.Text == "")
                textBox_scene_refl.Text = "0";
            var d = (float)double.Parse(textBox_scene_refl.Text);
            scene[sceneBox.SelectedIndex].reflective = Math.Min(1, Math.Max(d, 0));
            //textBox_scene_refl.Text = scene[sceneBox.SelectedIndex].reflective.ToString();
            show_scene1();
        }

        private void textBox_scene_transp_TextChanged(object sender, EventArgs e)
        {
            if (textBox_scene_transp.Text == "")
                textBox_scene_transp.Text = "0";
            var d = (float)double.Parse(textBox_scene_transp.Text);
            scene[sceneBox.SelectedIndex].transparent = Math.Min(1, Math.Max(d, 0));
            //textBox_scene_transp.Text = scene[sceneBox.SelectedIndex].transparent.ToString();
            show_scene1();
        }
    }
}
