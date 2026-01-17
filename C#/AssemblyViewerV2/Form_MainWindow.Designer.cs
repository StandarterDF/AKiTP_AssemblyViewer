namespace AssemblyViewerV2
{
    partial class ProgramMainForm
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
            this.TableLayout_Main = new System.Windows.Forms.TableLayoutPanel();
            this.TableLayout_Category_Tools = new System.Windows.Forms.TableLayoutPanel();
            this.GroupBox_SelectAssembly = new System.Windows.Forms.GroupBox();
            this.ComboBox_SelectAssembly = new System.Windows.Forms.ComboBox();
            this.GroupBox_AssemblyTools = new System.Windows.Forms.GroupBox();
            this.Button_AssemblyEdit = new System.Windows.Forms.Button();
            this.TextBox_Version = new System.Windows.Forms.TextBox();
            this.TextBox_AuthorName = new System.Windows.Forms.TextBox();
            this.Label_AssemblyVersion = new System.Windows.Forms.Label();
            this.Label_AssemblyAuthor = new System.Windows.Forms.Label();
            this.Button_AssemblyBOM = new System.Windows.Forms.Button();
            this.Button_AssemblyDelete = new System.Windows.Forms.Button();
            this.Button_AssemblyInfo = new System.Windows.Forms.Button();
            this.GroupBox_DetailTools = new System.Windows.Forms.GroupBox();
            this.Button_EditDetail = new System.Windows.Forms.Button();
            this.Button_RemoveDetail = new System.Windows.Forms.Button();
            this.Button_AddDetail = new System.Windows.Forms.Button();
            this.Button_DetailInfo = new System.Windows.Forms.Button();
            this.TableSQL_MainWindow = new System.Windows.Forms.DataGridView();
            this.ContextMenu_File = new System.Windows.Forms.ToolStripMenuItem();
            this.импортToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ImportExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.экспортToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExportExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExportWordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenu_Assembly = new System.Windows.Forms.ToolStripMenuItem();
            this.сборкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenu_CreateAssembly = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenu_AddInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenu_Info = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenu = new System.Windows.Forms.MenuStrip();
            this.TableLayout_Main.SuspendLayout();
            this.TableLayout_Category_Tools.SuspendLayout();
            this.GroupBox_SelectAssembly.SuspendLayout();
            this.GroupBox_AssemblyTools.SuspendLayout();
            this.GroupBox_DetailTools.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TableSQL_MainWindow)).BeginInit();
            this.ContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // TableLayout_Main
            // 
            this.TableLayout_Main.ColumnCount = 2;
            this.TableLayout_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.375F));
            this.TableLayout_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72.625F));
            this.TableLayout_Main.Controls.Add(this.TableLayout_Category_Tools, 0, 0);
            this.TableLayout_Main.Controls.Add(this.TableSQL_MainWindow, 1, 0);
            this.TableLayout_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayout_Main.Location = new System.Drawing.Point(0, 24);
            this.TableLayout_Main.Name = "TableLayout_Main";
            this.TableLayout_Main.RowCount = 1;
            this.TableLayout_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayout_Main.Size = new System.Drawing.Size(800, 426);
            this.TableLayout_Main.TabIndex = 1;
            // 
            // TableLayout_Category_Tools
            // 
            this.TableLayout_Category_Tools.ColumnCount = 1;
            this.TableLayout_Category_Tools.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayout_Category_Tools.Controls.Add(this.GroupBox_SelectAssembly, 0, 0);
            this.TableLayout_Category_Tools.Controls.Add(this.GroupBox_AssemblyTools, 0, 1);
            this.TableLayout_Category_Tools.Controls.Add(this.GroupBox_DetailTools, 0, 2);
            this.TableLayout_Category_Tools.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayout_Category_Tools.Location = new System.Drawing.Point(3, 3);
            this.TableLayout_Category_Tools.Name = "TableLayout_Category_Tools";
            this.TableLayout_Category_Tools.RowCount = 3;
            this.TableLayout_Category_Tools.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 63F));
            this.TableLayout_Category_Tools.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 215F));
            this.TableLayout_Category_Tools.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.TableLayout_Category_Tools.Size = new System.Drawing.Size(213, 420);
            this.TableLayout_Category_Tools.TabIndex = 0;
            // 
            // GroupBox_SelectAssembly
            // 
            this.GroupBox_SelectAssembly.Controls.Add(this.ComboBox_SelectAssembly);
            this.GroupBox_SelectAssembly.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GroupBox_SelectAssembly.Location = new System.Drawing.Point(3, 3);
            this.GroupBox_SelectAssembly.Name = "GroupBox_SelectAssembly";
            this.GroupBox_SelectAssembly.Size = new System.Drawing.Size(207, 57);
            this.GroupBox_SelectAssembly.TabIndex = 0;
            this.GroupBox_SelectAssembly.TabStop = false;
            this.GroupBox_SelectAssembly.Text = "Выбор сборки";
            // 
            // ComboBox_SelectAssembly
            // 
            this.ComboBox_SelectAssembly.FormattingEnabled = true;
            this.ComboBox_SelectAssembly.Location = new System.Drawing.Point(6, 19);
            this.ComboBox_SelectAssembly.Name = "ComboBox_SelectAssembly";
            this.ComboBox_SelectAssembly.Size = new System.Drawing.Size(195, 21);
            this.ComboBox_SelectAssembly.TabIndex = 0;
            this.ComboBox_SelectAssembly.SelectedIndexChanged += new System.EventHandler(this.ComboBox_SelectAssembly_SelectedIndexChanged);
            // 
            // GroupBox_AssemblyTools
            // 
            this.GroupBox_AssemblyTools.Controls.Add(this.Button_AssemblyEdit);
            this.GroupBox_AssemblyTools.Controls.Add(this.TextBox_Version);
            this.GroupBox_AssemblyTools.Controls.Add(this.TextBox_AuthorName);
            this.GroupBox_AssemblyTools.Controls.Add(this.Label_AssemblyVersion);
            this.GroupBox_AssemblyTools.Controls.Add(this.Label_AssemblyAuthor);
            this.GroupBox_AssemblyTools.Controls.Add(this.Button_AssemblyBOM);
            this.GroupBox_AssemblyTools.Controls.Add(this.Button_AssemblyDelete);
            this.GroupBox_AssemblyTools.Controls.Add(this.Button_AssemblyInfo);
            this.GroupBox_AssemblyTools.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GroupBox_AssemblyTools.Location = new System.Drawing.Point(3, 66);
            this.GroupBox_AssemblyTools.Name = "GroupBox_AssemblyTools";
            this.GroupBox_AssemblyTools.Size = new System.Drawing.Size(207, 209);
            this.GroupBox_AssemblyTools.TabIndex = 1;
            this.GroupBox_AssemblyTools.TabStop = false;
            this.GroupBox_AssemblyTools.Text = "Управление сборкой";
            // 
            // Button_AssemblyEdit
            // 
            this.Button_AssemblyEdit.Location = new System.Drawing.Point(8, 122);
            this.Button_AssemblyEdit.Name = "Button_AssemblyEdit";
            this.Button_AssemblyEdit.Size = new System.Drawing.Size(195, 23);
            this.Button_AssemblyEdit.TabIndex = 7;
            this.Button_AssemblyEdit.Text = "Редактировать сборку";
            this.Button_AssemblyEdit.UseVisualStyleBackColor = true;
            this.Button_AssemblyEdit.Click += new System.EventHandler(this.Button_AssemblyEdit_click);
            // 
            // TextBox_Version
            // 
            this.TextBox_Version.Location = new System.Drawing.Point(101, 44);
            this.TextBox_Version.Name = "TextBox_Version";
            this.TextBox_Version.Size = new System.Drawing.Size(100, 20);
            this.TextBox_Version.TabIndex = 6;
            // 
            // TextBox_AuthorName
            // 
            this.TextBox_AuthorName.Location = new System.Drawing.Point(101, 18);
            this.TextBox_AuthorName.Name = "TextBox_AuthorName";
            this.TextBox_AuthorName.Size = new System.Drawing.Size(100, 20);
            this.TextBox_AuthorName.TabIndex = 5;
            // 
            // Label_AssemblyVersion
            // 
            this.Label_AssemblyVersion.AutoSize = true;
            this.Label_AssemblyVersion.Location = new System.Drawing.Point(12, 47);
            this.Label_AssemblyVersion.Name = "Label_AssemblyVersion";
            this.Label_AssemblyVersion.Size = new System.Drawing.Size(86, 13);
            this.Label_AssemblyVersion.TabIndex = 4;
            this.Label_AssemblyVersion.Text = "Версия сборки:";
            // 
            // Label_AssemblyAuthor
            // 
            this.Label_AssemblyAuthor.AutoSize = true;
            this.Label_AssemblyAuthor.Location = new System.Drawing.Point(12, 21);
            this.Label_AssemblyAuthor.Name = "Label_AssemblyAuthor";
            this.Label_AssemblyAuthor.Size = new System.Drawing.Size(79, 13);
            this.Label_AssemblyAuthor.TabIndex = 3;
            this.Label_AssemblyAuthor.Text = "Автор сборки:";
            // 
            // Button_AssemblyBOM
            // 
            this.Button_AssemblyBOM.Location = new System.Drawing.Point(8, 81);
            this.Button_AssemblyBOM.Name = "Button_AssemblyBOM";
            this.Button_AssemblyBOM.Size = new System.Drawing.Size(194, 23);
            this.Button_AssemblyBOM.TabIndex = 2;
            this.Button_AssemblyBOM.Text = "Сгенерировать BOM";
            this.Button_AssemblyBOM.UseVisualStyleBackColor = true;
            this.Button_AssemblyBOM.Click += new System.EventHandler(this.Button_AssemblyBOM_Click);
            // 
            // Button_AssemblyDelete
            // 
            this.Button_AssemblyDelete.Location = new System.Drawing.Point(8, 180);
            this.Button_AssemblyDelete.Name = "Button_AssemblyDelete";
            this.Button_AssemblyDelete.Size = new System.Drawing.Size(195, 23);
            this.Button_AssemblyDelete.TabIndex = 1;
            this.Button_AssemblyDelete.Text = "Удалить сборку";
            this.Button_AssemblyDelete.UseVisualStyleBackColor = true;
            this.Button_AssemblyDelete.Click += new System.EventHandler(this.Button_AssemblyDelete_Click);
            // 
            // Button_AssemblyInfo
            // 
            this.Button_AssemblyInfo.Location = new System.Drawing.Point(8, 151);
            this.Button_AssemblyInfo.Name = "Button_AssemblyInfo";
            this.Button_AssemblyInfo.Size = new System.Drawing.Size(195, 23);
            this.Button_AssemblyInfo.TabIndex = 0;
            this.Button_AssemblyInfo.Text = "Информация о сборке";
            this.Button_AssemblyInfo.UseVisualStyleBackColor = true;
            this.Button_AssemblyInfo.Click += new System.EventHandler(this.Button_AssemblyInfo_Click);
            // 
            // GroupBox_DetailTools
            // 
            this.GroupBox_DetailTools.Controls.Add(this.Button_EditDetail);
            this.GroupBox_DetailTools.Controls.Add(this.Button_RemoveDetail);
            this.GroupBox_DetailTools.Controls.Add(this.Button_AddDetail);
            this.GroupBox_DetailTools.Controls.Add(this.Button_DetailInfo);
            this.GroupBox_DetailTools.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GroupBox_DetailTools.Location = new System.Drawing.Point(3, 281);
            this.GroupBox_DetailTools.Name = "GroupBox_DetailTools";
            this.GroupBox_DetailTools.Size = new System.Drawing.Size(207, 136);
            this.GroupBox_DetailTools.TabIndex = 2;
            this.GroupBox_DetailTools.TabStop = false;
            this.GroupBox_DetailTools.Text = "Управление деталью";
            // 
            // Button_EditDetail
            // 
            this.Button_EditDetail.Location = new System.Drawing.Point(7, 77);
            this.Button_EditDetail.Name = "Button_EditDetail";
            this.Button_EditDetail.Size = new System.Drawing.Size(195, 23);
            this.Button_EditDetail.TabIndex = 3;
            this.Button_EditDetail.Text = "Редактировать деталь";
            this.Button_EditDetail.UseVisualStyleBackColor = true;
            this.Button_EditDetail.Click += new System.EventHandler(this.Button_EditDetail_Click);
            // 
            // Button_RemoveDetail
            // 
            this.Button_RemoveDetail.Location = new System.Drawing.Point(6, 48);
            this.Button_RemoveDetail.Name = "Button_RemoveDetail";
            this.Button_RemoveDetail.Size = new System.Drawing.Size(195, 23);
            this.Button_RemoveDetail.TabIndex = 2;
            this.Button_RemoveDetail.Text = "Удалить деталь";
            this.Button_RemoveDetail.UseVisualStyleBackColor = true;
            this.Button_RemoveDetail.Click += new System.EventHandler(this.Button_RemoveDetail_Click);
            // 
            // Button_AddDetail
            // 
            this.Button_AddDetail.Location = new System.Drawing.Point(7, 19);
            this.Button_AddDetail.Name = "Button_AddDetail";
            this.Button_AddDetail.Size = new System.Drawing.Size(195, 23);
            this.Button_AddDetail.TabIndex = 1;
            this.Button_AddDetail.Text = "Добавить деталь";
            this.Button_AddDetail.UseVisualStyleBackColor = true;
            this.Button_AddDetail.Click += new System.EventHandler(this.Button_AddDetail_Click);
            // 
            // Button_DetailInfo
            // 
            this.Button_DetailInfo.Location = new System.Drawing.Point(8, 106);
            this.Button_DetailInfo.Name = "Button_DetailInfo";
            this.Button_DetailInfo.Size = new System.Drawing.Size(195, 23);
            this.Button_DetailInfo.TabIndex = 0;
            this.Button_DetailInfo.Text = "Информация о детали";
            this.Button_DetailInfo.UseVisualStyleBackColor = true;
            this.Button_DetailInfo.Click += new System.EventHandler(this.Button_DetailInfo_Click);
            // 
            // TableSQL_MainWindow
            // 
            this.TableSQL_MainWindow.AllowUserToAddRows = false;
            this.TableSQL_MainWindow.AllowUserToDeleteRows = false;
            this.TableSQL_MainWindow.BackgroundColor = System.Drawing.SystemColors.Window;
            this.TableSQL_MainWindow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TableSQL_MainWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableSQL_MainWindow.Location = new System.Drawing.Point(222, 3);
            this.TableSQL_MainWindow.Name = "TableSQL_MainWindow";
            this.TableSQL_MainWindow.ReadOnly = true;
            this.TableSQL_MainWindow.Size = new System.Drawing.Size(575, 420);
            this.TableSQL_MainWindow.TabIndex = 1;
            this.TableSQL_MainWindow.Click += new System.EventHandler(this.TableSQL_MainWindow_Click);
            // 
            // ContextMenu_File
            // 
            this.ContextMenu_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.импортToolStripMenuItem,
            this.экспортToolStripMenuItem,
            this.SettingsToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.ContextMenu_File.Name = "ContextMenu_File";
            this.ContextMenu_File.Size = new System.Drawing.Size(48, 20);
            this.ContextMenu_File.Text = "Файл";
            // 
            // импортToolStripMenuItem
            // 
            this.импортToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ImportExcelToolStripMenuItem});
            this.импортToolStripMenuItem.Name = "импортToolStripMenuItem";
            this.импортToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.импортToolStripMenuItem.Text = "Импорт";
            // 
            // ImportExcelToolStripMenuItem
            // 
            this.ImportExcelToolStripMenuItem.Name = "ImportExcelToolStripMenuItem";
            this.ImportExcelToolStripMenuItem.Size = new System.Drawing.Size(259, 22);
            this.ImportExcelToolStripMenuItem.Text = "Импортировать из Excel (Сборка)";
            this.ImportExcelToolStripMenuItem.Click += new System.EventHandler(this.ImportExcelToolStripMenuItem_Click);
            // 
            // экспортToolStripMenuItem
            // 
            this.экспортToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ExportExcelToolStripMenuItem,
            this.ExportWordToolStripMenuItem});
            this.экспортToolStripMenuItem.Name = "экспортToolStripMenuItem";
            this.экспортToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.экспортToolStripMenuItem.Text = "Экспорт";
            // 
            // ExportExcelToolStripMenuItem
            // 
            this.ExportExcelToolStripMenuItem.Name = "ExportExcelToolStripMenuItem";
            this.ExportExcelToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            this.ExportExcelToolStripMenuItem.Text = "Экспортировать в Excel (Сборка)";
            this.ExportExcelToolStripMenuItem.Click += new System.EventHandler(this.ExportExcelToolStripMenuItem_Click);
            // 
            // ExportWordToolStripMenuItem
            // 
            this.ExportWordToolStripMenuItem.Name = "ExportWordToolStripMenuItem";
            this.ExportWordToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            this.ExportWordToolStripMenuItem.Text = "Экспортировать в Word (Сборка)";
            this.ExportWordToolStripMenuItem.Click += new System.EventHandler(this.ExportWordToolStripMenuItem_Click);
            // 
            // SettingsToolStripMenuItem
            // 
            this.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem";
            this.SettingsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.SettingsToolStripMenuItem.Text = "Настройки";
            this.SettingsToolStripMenuItem.Click += new System.EventHandler(this.SettingsToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            // 
            // ContextMenu_Assembly
            // 
            this.ContextMenu_Assembly.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сборкаToolStripMenuItem});
            this.ContextMenu_Assembly.Name = "ContextMenu_Assembly";
            this.ContextMenu_Assembly.Size = new System.Drawing.Size(59, 20);
            this.ContextMenu_Assembly.Text = "Проект";
            // 
            // сборкаToolStripMenuItem
            // 
            this.сборкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ContextMenu_CreateAssembly});
            this.сборкаToolStripMenuItem.Name = "сборкаToolStripMenuItem";
            this.сборкаToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.сборкаToolStripMenuItem.Text = "Сборка";
            // 
            // ContextMenu_CreateAssembly
            // 
            this.ContextMenu_CreateAssembly.Name = "ContextMenu_CreateAssembly";
            this.ContextMenu_CreateAssembly.Size = new System.Drawing.Size(198, 22);
            this.ContextMenu_CreateAssembly.Text = "Создать новую сборку";
            this.ContextMenu_CreateAssembly.Click += new System.EventHandler(this.ContextMenu_CreateAssembly_Click);
            // 
            // ContextMenu_AddInfo
            // 
            this.ContextMenu_AddInfo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ContextMenu_Info});
            this.ContextMenu_AddInfo.Name = "ContextMenu_AddInfo";
            this.ContextMenu_AddInfo.Size = new System.Drawing.Size(65, 20);
            this.ContextMenu_AddInfo.Text = "Справка";
            // 
            // ContextMenu_Info
            // 
            this.ContextMenu_Info.Name = "ContextMenu_Info";
            this.ContextMenu_Info.Size = new System.Drawing.Size(224, 22);
            this.ContextMenu_Info.Text = "Информация о программе";
            this.ContextMenu_Info.Click += new System.EventHandler(this.ContextMenu_Info_Click);
            // 
            // ContextMenu
            // 
            this.ContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ContextMenu_File,
            this.ContextMenu_Assembly,
            this.ContextMenu_AddInfo});
            this.ContextMenu.Location = new System.Drawing.Point(0, 0);
            this.ContextMenu.Name = "ContextMenu";
            this.ContextMenu.Size = new System.Drawing.Size(800, 24);
            this.ContextMenu.TabIndex = 0;
            this.ContextMenu.Text = "menuStrip1";
            // 
            // ProgramMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TableLayout_Main);
            this.Controls.Add(this.ContextMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.ContextMenu;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProgramMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AssemblyViewer V2";
            this.Load += new System.EventHandler(this.ProgramMainForm_Load);
            this.TableLayout_Main.ResumeLayout(false);
            this.TableLayout_Category_Tools.ResumeLayout(false);
            this.GroupBox_SelectAssembly.ResumeLayout(false);
            this.GroupBox_AssemblyTools.ResumeLayout(false);
            this.GroupBox_AssemblyTools.PerformLayout();
            this.GroupBox_DetailTools.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TableSQL_MainWindow)).EndInit();
            this.ContextMenu.ResumeLayout(false);
            this.ContextMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel TableLayout_Main;
        private System.Windows.Forms.TableLayoutPanel TableLayout_Category_Tools;
        private System.Windows.Forms.GroupBox GroupBox_SelectAssembly;
        private System.Windows.Forms.ComboBox ComboBox_SelectAssembly;
        private System.Windows.Forms.GroupBox GroupBox_AssemblyTools;
        private System.Windows.Forms.GroupBox GroupBox_DetailTools;
        private System.Windows.Forms.Button Button_AssemblyInfo;
        private System.Windows.Forms.Button Button_DetailInfo;
        private System.Windows.Forms.DataGridView TableSQL_MainWindow;
        private System.Windows.Forms.Button Button_EditDetail;
        private System.Windows.Forms.Button Button_RemoveDetail;
        private System.Windows.Forms.Button Button_AddDetail;
        private System.Windows.Forms.Button Button_AssemblyBOM;
        private System.Windows.Forms.Button Button_AssemblyDelete;
        private System.Windows.Forms.Label Label_AssemblyVersion;
        private System.Windows.Forms.Label Label_AssemblyAuthor;
        private System.Windows.Forms.TextBox TextBox_Version;
        private System.Windows.Forms.TextBox TextBox_AuthorName;
        private System.Windows.Forms.Button Button_AssemblyEdit;
        private System.Windows.Forms.ToolStripMenuItem ContextMenu_File;
        private System.Windows.Forms.ToolStripMenuItem ContextMenu_Assembly;
        private System.Windows.Forms.ToolStripMenuItem ContextMenu_AddInfo;
        private System.Windows.Forms.ToolStripMenuItem ContextMenu_Info;
        private System.Windows.Forms.MenuStrip ContextMenu;
        private System.Windows.Forms.ToolStripMenuItem сборкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ContextMenu_CreateAssembly;
        private System.Windows.Forms.ToolStripMenuItem импортToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem экспортToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ImportExcelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExportExcelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExportWordToolStripMenuItem;
    }
}

