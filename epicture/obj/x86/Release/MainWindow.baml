   M S B A M L   `   `   `  ���� C  ?epicture, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:epictureepicture      epicture.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     (localclr-namespace:epicture       � Title$  Epicture��$	��720��$	��600�� � WindowStartupLocation$ CenterScreen=� � 
ResizeMode$ NoResize=� � DataContext ��  �� RelativeSource �� *Self+ � 	Resources  	  Style �� 
TargetType �� Property �� Value  listBoxTemplate	 �Name
 � Cursor �� Orientation J� RenderTransformOrigin �� Triggers P� Property P� Value �� 
TargetName��%�  &	        &	 %     �� " ��.���  � ��
 � ����� .R��� $��3q�.+�]� .+��� $	��150������ *Url+]� .+��� -   $��Add to favorites�����	#CC41B1E1���� .R�� $	 ADDFAV��$��0,7,0,10q�.+��� $

 Hand��$ 
Horizontal=�$ 0.5,0.5&�.+��� $

 Hand��$��Icons/add.png��$��37��$��
31,0,30,10q�$ -0.528,0.372&��� 
�������$��18(�$��Arial)�$��Center=�$��Center=�Add to favorites P�  �@J�IsMouseOver . . ��� $ ADDFAV�� � ��
 �   �]� .+��� -   $��Remove from favorites������ .R�� $	 SUPPRFAV��$��0,7,0,10q�.+��� $

 Hand��$ 
Horizontal=�$ 0.5,0.5&�.+��� $

 Hand��$��Icons/suprr.png��$��37��$��
31,0,30,10q�$ -0.528,0.372&��� 
�������$��18(�$��Arial)�$��Center=�$��Center=�Delete from favorites P�  �@J�IsMouseOver . . ��� $ SUPPRFAV�� � ��
 �   �.��� 
���   � � ColumnDefinitions �� $��0* ��� .+�� -   $��
connection��$y�	Collapsed=�$ 
0.474,0.48&�$��2�� �� $��0* ��� .+��� -   $��ID��$��Center=�$��24��$��
0,-150,0,0q� �� TextWrapping$
 Wrap=�$��	Client ID��$��Center=�$	��120��$ 0.125,-3.984&�$��1��$��16(��� -   $��IDSecret��$��Center=�$��23��$��	0,-50,0,0q�$
 Wrap=�$��Client Secret��$��Center=�$	��120��$��1��$��16(��� -   $��Connect��$��Center=�$��	0,100,0,0q�$��Center=�$��74��$��1��$��20��� -   $��program��$y�Visible=�$��2��.+��� -   $��	searching��
�������$��22(�$��Calibri)�$��33��$
 Wrap=�$��50,10,10,10q�$	��Top=��� -	   $	��Fav��$��
Go to Favorite��$��	10,36,0,0q�$
��left=�$	��Top=�$��52��$	��164������ .R�� $		 btn��$��0,7,0,10q�.+��� $

 Hand��$ 
Horizontal=�$ 0.5,0.5&�.+��� $��Center=�$��	UltraBold"�
�������$��16(�$��Center=�$	��120���� $�Go to favorites���� $��2,-3,0,0q�$��Icons/favoris.png��$��40��$
��left=�$ -0.529,0.372&� P�  �@J�IsMouseOver . . ��� $	 btn�� � ��
 ������� -
   $
��Left=�$	��Top=�$��35��$��9,10,0,0q�$ -0.125,0.386&�$��40������ .R�� $	 bg��.+��� $

 Hand��$��Icons/tick1.png�� P�  �@J�IsMouseOver . . ��� $ bg�� � ��
 ������� -   $
��type��$��18(�$��Calibri)�$��Right=�$��	0,47,10,0q�$��30��$	��121��$	��Top=�.@���  �� 
IsSelected . .��	all types�� .��Jpg�� .��Png�� .��Gif�� .��Anigif�� -   $��format��$	��Top=�$��Right=�$��18(�$��Calibri)�$��30��$	��121��$��
0,47,173,0q�.@���  . .��
all size�� $��Small���� $��Medium���� $	��Big���� $��Large���� $��Hudge���� -   $��listBox1��#��[ $��10,81,10,19q����� *
Contents+