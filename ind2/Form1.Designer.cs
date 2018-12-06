namespace lab6
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label5 = new System.Windows.Forms.Label();
            this.camera_x = new System.Windows.Forms.Label();
            this.camera_y = new System.Windows.Forms.Label();
            this.camera_z = new System.Windows.Forms.Label();
            this.rot_angle_camera = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button_exec_camera = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label_light_color = new System.Windows.Forms.Label();
            this.label_light_type = new System.Windows.Forms.Label();
            this.label_light_pos = new System.Windows.Forms.Label();
            this.checkBox_light = new System.Windows.Forms.CheckBox();
            this.lightBox = new System.Windows.Forms.ListBox();
            this.colorDialog2 = new System.Windows.Forms.ColorDialog();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.sceneBox = new System.Windows.Forms.ListBox();
            this.label_scene_comment = new System.Windows.Forms.Label();
            this.label_scene_specular = new System.Windows.Forms.Label();
            this.label_scene_reflective = new System.Windows.Forms.Label();
            this.label_scene_transparent = new System.Windows.Forms.Label();
            this.label_scene_color = new System.Windows.Forms.Label();
            this.textBox_scene_spec = new System.Windows.Forms.TextBox();
            this.textBox_scene_refl = new System.Windows.Forms.TextBox();
            this.textBox_scene_transp = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(329, 406);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 17);
            this.label5.TabIndex = 61;
            this.label5.Text = "Camera";
            // 
            // camera_x
            // 
            this.camera_x.AutoSize = true;
            this.camera_x.Location = new System.Drawing.Point(332, 427);
            this.camera_x.Name = "camera_x";
            this.camera_x.Size = new System.Drawing.Size(16, 17);
            this.camera_x.TabIndex = 62;
            this.camera_x.Text = "0";
            // 
            // camera_y
            // 
            this.camera_y.AutoSize = true;
            this.camera_y.Location = new System.Drawing.Point(370, 427);
            this.camera_y.Name = "camera_y";
            this.camera_y.Size = new System.Drawing.Size(16, 17);
            this.camera_y.TabIndex = 63;
            this.camera_y.Text = "0";
            // 
            // camera_z
            // 
            this.camera_z.AutoSize = true;
            this.camera_z.Location = new System.Drawing.Point(408, 427);
            this.camera_z.Name = "camera_z";
            this.camera_z.Size = new System.Drawing.Size(32, 17);
            this.camera_z.TabIndex = 64;
            this.camera_z.Text = "500";
            // 
            // rot_angle_camera
            // 
            this.rot_angle_camera.Location = new System.Drawing.Point(340, 478);
            this.rot_angle_camera.Margin = new System.Windows.Forms.Padding(4);
            this.rot_angle_camera.Name = "rot_angle_camera";
            this.rot_angle_camera.Size = new System.Drawing.Size(89, 22);
            this.rot_angle_camera.TabIndex = 72;
            this.rot_angle_camera.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(324, 457);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(113, 17);
            this.label8.TabIndex = 71;
            this.label8.Text = "Поворот (angle)";
            // 
            // button_exec_camera
            // 
            this.button_exec_camera.Location = new System.Drawing.Point(335, 518);
            this.button_exec_camera.Margin = new System.Windows.Forms.Padding(4);
            this.button_exec_camera.Name = "button_exec_camera";
            this.button_exec_camera.Size = new System.Drawing.Size(100, 29);
            this.button_exec_camera.TabIndex = 73;
            this.button_exec_camera.Text = "Выполнить";
            this.button_exec_camera.UseVisualStyleBackColor = true;
            this.button_exec_camera.Click += new System.EventHandler(this.button_exec_camera_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.White;
            this.pictureBox3.Location = new System.Drawing.Point(549, 26);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(700, 700);
            this.pictureBox3.TabIndex = 76;
            this.pictureBox3.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 367);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 17);
            this.label1.TabIndex = 77;
            this.label1.Text = "Свойства фигур:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(194, 17);
            this.label2.TabIndex = 78;
            this.label2.Text = "Свойства источников света:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(307, 264);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(156, 131);
            this.pictureBox1.TabIndex = 79;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(355, 242);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 17);
            this.label3.TabIndex = 80;
            this.label3.Text = "Preview";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(812, 778);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(143, 40);
            this.button1.TabIndex = 81;
            this.button1.Text = "Сгенерировать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label_light_color
            // 
            this.label_light_color.AutoSize = true;
            this.label_light_color.Location = new System.Drawing.Point(114, 264);
            this.label_light_color.Name = "label_light_color";
            this.label_light_color.Size = new System.Drawing.Size(41, 17);
            this.label_light_color.TabIndex = 82;
            this.label_light_color.Text = "Color";
            this.label_light_color.Click += new System.EventHandler(this.label_light_color_Click);
            // 
            // label_light_type
            // 
            this.label_light_type.AutoSize = true;
            this.label_light_type.Location = new System.Drawing.Point(149, 207);
            this.label_light_type.Name = "label_light_type";
            this.label_light_type.Size = new System.Drawing.Size(35, 17);
            this.label_light_type.TabIndex = 83;
            this.label_light_type.Text = "type";
            // 
            // label_light_pos
            // 
            this.label_light_pos.AutoSize = true;
            this.label_light_pos.Location = new System.Drawing.Point(149, 235);
            this.label_light_pos.Name = "label_light_pos";
            this.label_light_pos.Size = new System.Drawing.Size(57, 17);
            this.label_light_pos.TabIndex = 84;
            this.label_light_pos.Text = "position";
            // 
            // checkBox_light
            // 
            this.checkBox_light.AutoSize = true;
            this.checkBox_light.Location = new System.Drawing.Point(91, 293);
            this.checkBox_light.Name = "checkBox_light";
            this.checkBox_light.Size = new System.Drawing.Size(82, 21);
            this.checkBox_light.TabIndex = 85;
            this.checkBox_light.Text = "Enabled";
            this.checkBox_light.UseVisualStyleBackColor = true;
            this.checkBox_light.CheckedChanged += new System.EventHandler(this.checkBox_light_CheckedChanged);
            // 
            // lightBox
            // 
            this.lightBox.FormattingEnabled = true;
            this.lightBox.ItemHeight = 16;
            this.lightBox.Location = new System.Drawing.Point(51, 57);
            this.lightBox.Name = "lightBox";
            this.lightBox.Size = new System.Drawing.Size(191, 132);
            this.lightBox.TabIndex = 88;
            this.lightBox.SelectedIndexChanged += new System.EventHandler(this.lightBox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(75, 207);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 17);
            this.label4.TabIndex = 89;
            this.label4.Text = "Type:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(77, 235);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 17);
            this.label6.TabIndex = 90;
            this.label6.Text = "Position:";
            // 
            // sceneBox
            // 
            this.sceneBox.FormattingEnabled = true;
            this.sceneBox.ItemHeight = 16;
            this.sceneBox.Location = new System.Drawing.Point(51, 394);
            this.sceneBox.Name = "sceneBox";
            this.sceneBox.Size = new System.Drawing.Size(191, 132);
            this.sceneBox.TabIndex = 91;
            this.sceneBox.SelectedIndexChanged += new System.EventHandler(this.sceneBox_SelectedIndexChanged);
            // 
            // label_scene_comment
            // 
            this.label_scene_comment.AutoSize = true;
            this.label_scene_comment.Location = new System.Drawing.Point(77, 535);
            this.label_scene_comment.Name = "label_scene_comment";
            this.label_scene_comment.Size = new System.Drawing.Size(65, 17);
            this.label_scene_comment.TabIndex = 92;
            this.label_scene_comment.Text = "comment";
            // 
            // label_scene_specular
            // 
            this.label_scene_specular.AutoSize = true;
            this.label_scene_specular.Location = new System.Drawing.Point(52, 569);
            this.label_scene_specular.Name = "label_scene_specular";
            this.label_scene_specular.Size = new System.Drawing.Size(68, 17);
            this.label_scene_specular.TabIndex = 93;
            this.label_scene_specular.Text = "Specular:";
            // 
            // label_scene_reflective
            // 
            this.label_scene_reflective.AutoSize = true;
            this.label_scene_reflective.Location = new System.Drawing.Point(52, 600);
            this.label_scene_reflective.Name = "label_scene_reflective";
            this.label_scene_reflective.Size = new System.Drawing.Size(74, 17);
            this.label_scene_reflective.TabIndex = 94;
            this.label_scene_reflective.Text = "Reflective:";
            // 
            // label_scene_transparent
            // 
            this.label_scene_transparent.AutoSize = true;
            this.label_scene_transparent.Location = new System.Drawing.Point(52, 627);
            this.label_scene_transparent.Name = "label_scene_transparent";
            this.label_scene_transparent.Size = new System.Drawing.Size(90, 17);
            this.label_scene_transparent.TabIndex = 95;
            this.label_scene_transparent.Text = "Transparent:";
            // 
            // label_scene_color
            // 
            this.label_scene_color.AutoSize = true;
            this.label_scene_color.Location = new System.Drawing.Point(114, 663);
            this.label_scene_color.Name = "label_scene_color";
            this.label_scene_color.Size = new System.Drawing.Size(41, 17);
            this.label_scene_color.TabIndex = 96;
            this.label_scene_color.Text = "Color";
            this.label_scene_color.Click += new System.EventHandler(this.label_scene_color_Click);
            // 
            // textBox_scene_spec
            // 
            this.textBox_scene_spec.Location = new System.Drawing.Point(152, 567);
            this.textBox_scene_spec.Name = "textBox_scene_spec";
            this.textBox_scene_spec.Size = new System.Drawing.Size(100, 22);
            this.textBox_scene_spec.TabIndex = 97;
            this.textBox_scene_spec.TextChanged += new System.EventHandler(this.textBox_scene_spec_TextChanged);
            this.textBox_scene_spec.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress_double);
            // 
            // textBox_scene_refl
            // 
            this.textBox_scene_refl.Location = new System.Drawing.Point(152, 595);
            this.textBox_scene_refl.Name = "textBox_scene_refl";
            this.textBox_scene_refl.Size = new System.Drawing.Size(100, 22);
            this.textBox_scene_refl.TabIndex = 98;
            this.textBox_scene_refl.TextChanged += new System.EventHandler(this.textBox_scene_refl_TextChanged);
            this.textBox_scene_refl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress_double);
            // 
            // textBox_scene_transp
            // 
            this.textBox_scene_transp.Location = new System.Drawing.Point(152, 623);
            this.textBox_scene_transp.Name = "textBox_scene_transp";
            this.textBox_scene_transp.Size = new System.Drawing.Size(100, 22);
            this.textBox_scene_transp.TabIndex = 99;
            this.textBox_scene_transp.TextChanged += new System.EventHandler(this.textBox_scene_transp_TextChanged);
            this.textBox_scene_transp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress_double);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1303, 853);
            this.Controls.Add(this.textBox_scene_transp);
            this.Controls.Add(this.textBox_scene_refl);
            this.Controls.Add(this.textBox_scene_spec);
            this.Controls.Add(this.label_scene_color);
            this.Controls.Add(this.label_scene_transparent);
            this.Controls.Add(this.label_scene_reflective);
            this.Controls.Add(this.label_scene_specular);
            this.Controls.Add(this.label_scene_comment);
            this.Controls.Add(this.sceneBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lightBox);
            this.Controls.Add(this.checkBox_light);
            this.Controls.Add(this.label_light_pos);
            this.Controls.Add(this.label_light_type);
            this.Controls.Add(this.label_light_color);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.button_exec_camera);
            this.Controls.Add(this.rot_angle_camera);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.camera_z);
            this.Controls.Add(this.camera_y);
            this.Controls.Add(this.camera_x);
            this.Controls.Add(this.label5);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label camera_x;
        private System.Windows.Forms.Label camera_y;
        private System.Windows.Forms.Label camera_z;
        private System.Windows.Forms.TextBox rot_angle_camera;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button_exec_camera;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label_light_color;
        private System.Windows.Forms.Label label_light_type;
        private System.Windows.Forms.Label label_light_pos;
        private System.Windows.Forms.CheckBox checkBox_light;
        private System.Windows.Forms.ListBox lightBox;
        private System.Windows.Forms.ColorDialog colorDialog2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox sceneBox;
        private System.Windows.Forms.Label label_scene_comment;
        private System.Windows.Forms.Label label_scene_specular;
        private System.Windows.Forms.Label label_scene_reflective;
        private System.Windows.Forms.Label label_scene_transparent;
        private System.Windows.Forms.Label label_scene_color;
        private System.Windows.Forms.TextBox textBox_scene_spec;
        private System.Windows.Forms.TextBox textBox_scene_refl;
        private System.Windows.Forms.TextBox textBox_scene_transp;
    }
}

