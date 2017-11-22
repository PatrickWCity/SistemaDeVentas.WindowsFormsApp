namespace WindowsFormsApp1.Views
{
    partial class FormModoPago
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.l_ZonaMensaje = new System.Windows.Forms.Label();
            this.tb_Id = new System.Windows.Forms.TextBox();
            this.l_NumPago = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.B_Editar = new System.Windows.Forms.Button();
            this.B_Eliminar = new System.Windows.Forms.Button();
            this.B_Mostrar = new System.Windows.Forms.Button();
            this.B_Agregar = new System.Windows.Forms.Button();
            this.l_Detalles = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_Detalles = new System.Windows.Forms.TextBox();
            this.tb_Nombre = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // l_ZonaMensaje
            // 
            this.l_ZonaMensaje.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.l_ZonaMensaje.AutoSize = true;
            this.l_ZonaMensaje.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_ZonaMensaje.Location = new System.Drawing.Point(12, 397);
            this.l_ZonaMensaje.Name = "l_ZonaMensaje";
            this.l_ZonaMensaje.Size = new System.Drawing.Size(147, 19);
            this.l_ZonaMensaje.TabIndex = 23;
            this.l_ZonaMensaje.Text = "Zona de Mensaje";
            // 
            // tb_Id
            // 
            this.tb_Id.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_Id.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_Id.Location = new System.Drawing.Point(162, 14);
            this.tb_Id.Name = "tb_Id";
            this.tb_Id.Size = new System.Drawing.Size(361, 27);
            this.tb_Id.TabIndex = 22;
            // 
            // l_NumPago
            // 
            this.l_NumPago.AutoSize = true;
            this.l_NumPago.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_NumPago.Location = new System.Drawing.Point(12, 17);
            this.l_NumPago.Name = "l_NumPago";
            this.l_NumPago.Size = new System.Drawing.Size(144, 19);
            this.l_NumPago.TabIndex = 21;
            this.l_NumPago.Text = "Numero de Pago";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 152);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(625, 242);
            this.dataGridView1.TabIndex = 18;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellClick);
            // 
            // B_Editar
            // 
            this.B_Editar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.B_Editar.AutoSize = true;
            this.B_Editar.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B_Editar.Image = global::WindowsFormsApp1.Properties.Resources.pencil;
            this.B_Editar.Location = new System.Drawing.Point(529, 47);
            this.B_Editar.Name = "B_Editar";
            this.B_Editar.Size = new System.Drawing.Size(108, 29);
            this.B_Editar.TabIndex = 25;
            this.B_Editar.Text = "Editar";
            this.B_Editar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.B_Editar.UseVisualStyleBackColor = true;
            this.B_Editar.Click += new System.EventHandler(this.B_Editar_Click);
            // 
            // B_Eliminar
            // 
            this.B_Eliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.B_Eliminar.AutoSize = true;
            this.B_Eliminar.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B_Eliminar.Image = global::WindowsFormsApp1.Properties.Resources.trash;
            this.B_Eliminar.Location = new System.Drawing.Point(529, 82);
            this.B_Eliminar.Name = "B_Eliminar";
            this.B_Eliminar.Size = new System.Drawing.Size(108, 29);
            this.B_Eliminar.TabIndex = 24;
            this.B_Eliminar.Text = "Eliminar";
            this.B_Eliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.B_Eliminar.UseVisualStyleBackColor = true;
            this.B_Eliminar.Click += new System.EventHandler(this.B_Eliminar_Click);
            // 
            // B_Mostrar
            // 
            this.B_Mostrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.B_Mostrar.AutoSize = true;
            this.B_Mostrar.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B_Mostrar.Image = global::WindowsFormsApp1.Properties.Resources.eye;
            this.B_Mostrar.Location = new System.Drawing.Point(529, 117);
            this.B_Mostrar.Name = "B_Mostrar";
            this.B_Mostrar.Size = new System.Drawing.Size(108, 29);
            this.B_Mostrar.TabIndex = 20;
            this.B_Mostrar.Text = "Mostrar";
            this.B_Mostrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.B_Mostrar.UseVisualStyleBackColor = true;
            this.B_Mostrar.Click += new System.EventHandler(this.B_Mostrar_Click);
            // 
            // B_Agregar
            // 
            this.B_Agregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.B_Agregar.AutoSize = true;
            this.B_Agregar.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B_Agregar.Image = global::WindowsFormsApp1.Properties.Resources.plus;
            this.B_Agregar.Location = new System.Drawing.Point(529, 12);
            this.B_Agregar.Name = "B_Agregar";
            this.B_Agregar.Size = new System.Drawing.Size(108, 29);
            this.B_Agregar.TabIndex = 19;
            this.B_Agregar.Text = "Agregar";
            this.B_Agregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.B_Agregar.UseVisualStyleBackColor = true;
            this.B_Agregar.Click += new System.EventHandler(this.B_Agregar_Click);
            // 
            // l_Detalles
            // 
            this.l_Detalles.AutoSize = true;
            this.l_Detalles.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_Detalles.Location = new System.Drawing.Point(12, 87);
            this.l_Detalles.Name = "l_Detalles";
            this.l_Detalles.Size = new System.Drawing.Size(76, 19);
            this.l_Detalles.TabIndex = 29;
            this.l_Detalles.Text = "Detalles";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 19);
            this.label2.TabIndex = 28;
            this.label2.Text = "Nombre";
            // 
            // tb_Detalles
            // 
            this.tb_Detalles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_Detalles.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_Detalles.Location = new System.Drawing.Point(149, 84);
            this.tb_Detalles.Name = "tb_Detalles";
            this.tb_Detalles.Size = new System.Drawing.Size(374, 27);
            this.tb_Detalles.TabIndex = 27;
            // 
            // tb_Nombre
            // 
            this.tb_Nombre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_Nombre.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_Nombre.Location = new System.Drawing.Point(149, 49);
            this.tb_Nombre.Name = "tb_Nombre";
            this.tb_Nombre.Size = new System.Drawing.Size(374, 27);
            this.tb_Nombre.TabIndex = 26;
            // 
            // FormModoPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 425);
            this.Controls.Add(this.l_Detalles);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_Detalles);
            this.Controls.Add(this.tb_Nombre);
            this.Controls.Add(this.B_Editar);
            this.Controls.Add(this.B_Eliminar);
            this.Controls.Add(this.l_ZonaMensaje);
            this.Controls.Add(this.tb_Id);
            this.Controls.Add(this.l_NumPago);
            this.Controls.Add(this.B_Mostrar);
            this.Controls.Add(this.B_Agregar);
            this.Controls.Add(this.dataGridView1);
            this.MinimumSize = new System.Drawing.Size(665, 463);
            this.Name = "FormModoPago";
            this.Text = "FormModoPago";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button B_Editar;
        private System.Windows.Forms.Button B_Eliminar;
        private System.Windows.Forms.Label l_ZonaMensaje;
        private System.Windows.Forms.TextBox tb_Id;
        private System.Windows.Forms.Label l_NumPago;
        private System.Windows.Forms.Button B_Mostrar;
        private System.Windows.Forms.Button B_Agregar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label l_Detalles;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_Detalles;
        private System.Windows.Forms.TextBox tb_Nombre;
    }
}