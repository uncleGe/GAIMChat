   M S B A M L   `   `   `  ����I  EChattingClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:ChattingClientChattingClient  5   	       ChattingClient.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:ChattingClient     5   	     � Title$
  GAIM��5   	   $	��350��6   $	��525��6#   
���   ����	#FF64B5F6.��5	      � -   5         �Name$ WelcomeLabel��5	       � ColumnDefinitions 5
   
   �� 5      $
��377* �6   �� 5      $
��140* �6   .+�5   
   �� -   5         ��Name$ LoginButton��5      $��Login��6&   $��147,11.5,155.25,0q�66   $	��Top=�6Q   ���	#FF1565C0
�������
�������6�   �� 5   
   -   5         ��Name$ UserNameTextBox��5      $
��Left=�6+   $��23��6F   $��	10,10,0,0q�6R    �� TextWrapping$
 Wrap=�6e   $	��Top=�6y   $	��120��6�   ���	#FF1565C06�   �� 5   
   -   5        $ TextDisplayTextBox��5      $��10,54,22.059,54q�6.   ���	#FF1565C06G   �� 5   
   -   5        $ 
SendButton��5      $
��Send��6%   $��45.509,0,25.706,11q�64   $��Bottom=�6P   $��24��6k    �� 	IsDefault . ���	#FF1565C0
�������
������� J� RenderTransformOrigin$ 
-2.29,0.48&�6�   $��1��6  �� 5   
   -   5        $ MessageTextBox��5      $��23��6*   $��10,0,-40.509,11q�66   $
 Wrap=�6O   $��Bottom=�6c   ���	#FF1565C06~   �� 5   
   -   5         ��Name$ label��5      $��-10.243,4.183,10,0q�6   $	��Top=�6;   $��16(�6S   4  .System.Windows.Automation.AutomationProperties	   IsRequiredForForm	 . $�� ��6�   
   IsRowHeader
 . $��1��6�   �� 5   
   -   5         ��Name$ UsersListBox��5      $��1��6(   $��-17.059,76.941,10,54q�68   �� 5   
   -	   5        $ label1��5      $��Users:��6    $��1��61   $��Right=�6A   $��-17.059,50.981,99.065,0q�6]   $	��Top=�6~   ���	#FFFFF8F8$
��Bold"�6�   $��57.994��6�   5      5      