   M S B A M L   `   `   `  ����B  >TestApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:TestAppTestApp  5   	       TestApp.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:TestApp     5   	   b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  
MainWindow��5	   	   $	��600��6   $	��800��6)    � WindowStyle$ ThreeDBorderWindow=�65   .��5
      � ���#efebfa.+�5   
   �� $	��400��6   $��15q�6    
�������$��Center=�6?    �� Padding$ 30q�6Z   $	��550��6g    �� CornerRadius$ 20��6v    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 60Q�6#      Color$ 	LightGray��63      ShadowDepth$ 0Q�6E   ._�5      �� .+�5      �� $��Radio Transmitter ��6   $��30(�66   $
��Bold"�6D   $��0 0 0 20q�6V   � 5      -   5         �Name$ 	startGrid��5   (   $��0,0,0,0q�6   .+�5      �� -   5        $��FileNameTextBox��5   J   $
��Left=�5      $��50��69   $��	30,10,0,0q�6E   	 �� TextWrapping$
	 Wrap=�6X   $��Path file...��5      $	��Top=�6&   $	��250��6>   6J   �� 5      -   5        
 ��Name$
 BrowseButton��5      $��Browse a file��63   $
��Left=�6K   $��
330,20,0,0q�5      $	��Top=�6%   $	��120��6=    J� RenderTransformOrigin$ 1.047,0.821&�5      $��40��65   �� 5      -   5        $��
TextBlock1��5      $
��Left=�5       $��	30,90,0,0q�6<   $
��Wrap=�5      $	��Top=�6)   5      5      5      5      5      5      