   M S B A M L   `   `   `  ���� P  LBloc De Notas de Fede, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:BlocDeNotasBlocDeNotas      BlocDeNotas.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     +localclr-namespace:BlocDeNotas     b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  -     � Icon$  blocIcono.png��$��510.197��$	��847�� � Topmost .  � Title ��  �� Path$ NameArchivo� �� Mode$ TwoWay=� J� CommandBindings )  #System.Windows.Input.CommandBinding  -      Command$ ApplicationCommands.New��.��� $��0,2,2,0q�.+�o� $��33��$	��Top=�.@�m� $��Archivo��$��33��$��58��.@�m� -   $��Nuevo��$
��Left=�$��28��$	��220�� m� InputGestureText$ Ctrl + N�� m� Command$ ApplicationCommands.New��	 m� Icon	 �� $��	nuevo.png��m� -   
 m�Name$
 abrir��$��Abrir...��$
��Left=�$��28��$	��220��	 �� $��	abrir.png��m� -   $
 guardar��$��Guardar��$
��Left=�$��28��$	��220��	 �� $��Guardar.png��m� -   $
 guardarComo��$��Guardar como...��$
��Left=�$��29��$	��220��	 �� $��guardar como.png��m� $��Edición��$��33��$��58��.@�m� $��Copiar��$��28��$ ApplicationCommands.Copy��	 '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ ContentCopy=�m� $��Pegar��$��28��$ ApplicationCommands.Paste��	   $ ContentSave=�m� $��Cortar��$��28��$ ApplicationCommands.Cut��	   $ 
ContentCut=�m� $��Volver��$��28��$ ApplicationCommands.Undo��	   $ 	ArrowBack=��� m� $��Seleccionar todo��$��28��$# ApplicationCommands.SelectAll��	   $ 	SelectAll=�m� $��Insertar��$��33��$��58��.@�m� -   $��Ítem -Punto Negro-��$��28��	   $ CheckboxBlankCircle=�m� -   $��Ítem -Punto Blanco-��$��28��	 �� $��circulo blanco.png��m� -	   $��Ítem -Estrella-��$��28��	   $
 Star=�m� -
   $��Ítem -Chequeado-��$��28��	   $ Check=��� m� -   $	
 key��$��Fecha y Hora��$��28��$ F3��	   $ 	DateRange=�m� $��Fuente��$��33��$��58��.@�m� -   $��	ComicSans��$��
Comic Sans��$��28��$��Comic Sans MS)�	   $ 
FormatFont=�m� -   $��Arial��$��Arial��$��28��$��Arial)�	   $ 
FormatFont=�m� -   $��TimesNewRoman��$��Times New Roman��$��28��$��Times New Roman)�	   $ 
FormatFont=�m� -   $��Calibri��$��Calibri��$��28��$��Calibri)�	   $ 
FormatFont=�m� -   $��CalibriLight��$��Calibri Light��$��28��$��Calibri Light)�	   $ 
FormatFont=�m� -   $��Bahnschrift��$��Bahnschrift Light��$��28��$��Bahnschrift Light)�	   $ 
FormatFont=�m� -   $��Consolas��$��Consolas��$��28��$��	Consolas )�	   $ 
FormatFont=�m� -   $��LucidaConsole��$��Lucida Console��$��28��$��Lucida Console)�	   $ 
FormatFont=��� -   $��richBox��$��0,33,0,0q�$ �� HorizontalScrollBarVisibility$ Visible=�" �� VerticalScrollBarVisibility$ Visible=� �� 
AcceptsTab .  �� 
LineHeight$ 4��. �/� .T�J� .*�.*��� $� ��