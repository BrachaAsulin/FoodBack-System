   M S B A M L   `   `   `  ����N  JMonitoringLifestyle, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:MonitoringLifestyleMonitoringLifestyle  5      :    4MonitoringLifestyle.Views.foodInformationUserControl   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:MonitoringLifestyle     5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      h dMicrosoft.Expression.Interactions, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bei9http://schemas.microsoft.com/expression/2010/interactions  5      ���	#FF364E6F  � 	Resources  5         TextBoxBaseControlTemplate �� 
TargetType ��Name �� CornerRadius ��Name �� Triggers P� Property P� Value �� Value	 �� 
TargetName
 �� Property  ButtonBaseControlTemplate ��Name  ButtonStyle �� 
TargetType �� Triggers��%  &	        &	 :    &	     �� 5   
   " ��6=   .R�5      �� $ Bd��5      #��z��5      
���   �#��z��5      $ 7��6E   ._�5      �� $ PART_ContentHost��6   5       5      P� 5       � {� .  . �5      �� # � ��63   $	 Bd��6u   
 � ���� 5      # � ��63   
 � ��5      5      �� 5   
   " ��6<   .R�5      �� $ Bd��5      #��z��5      
���   �#��z��5      $	 100��6E   $��	0,-54,0,0q�6X   ._�5      �� $ PART_ContentHost��6   5      5      �� 5    
   " ��6$    5!      P� 5"       �@J�IsMouseOver . . �5#      �� 
 � ��
 ����63   5$      P� 5%       �@J�IsMouseOver .  . �5&      �� 
 � ��
 �   �63   5'      5)      5*      .��5+      � -   5         �Name$ foodInfoGrid��5+      
������� � RowDefinitions 5,   
   �� 5-      $��1* �6   �� 5.      $��1* �6   �� 5/      $��1* �6   �� 50      $��3* �6   .+�52   
   �� $��Food Information��6   $��36(�6,   $��Arial)�6:   $
��Bold"�6M   ���	#FF5A7900$��Center=�6v   $��Bottom=�6�   �� 53   
   ���	#FF893050$��Center=�6,   $��2��6I   $
��Wrap=�6V   $ ��Common foods by categories��6j   $��Bottom=�6�   ���	#FFF0F0F0$��22(�6�   $��Arial)�6�   $
��1090��6�   �� 54   
   #��[ 6   $#��Nutritional Values Calculator��6U   $��Center=�6}   $��1��6�   $��Bottom=�6�   $��24(�6�   
�������
�������$��Arial)�6�   ��66   �� *
Calculator+6�   � 55   
   $��3��6    � ColumnDefinitions 56      �� 57      �� 58      �� 59      �� 5:      .+�5<      �� $��	10,0,10,0q�6   $��0��6E   #��[ 6U   $��Stretch=�6�   $��16(�6�   $
��meat��6�   
���   �$	��100��6�   ��6(   �� *
MeatInfo+��5=      �� 5>       �� ImageSource$ /Resources/beef.jpg��6!    j� Stretch$ UniformToFill=�6C   5@      �� 5A      $��	10,0,10,0q�6   $��1��6F   #��[ 6V   $��Stretch=�6�   $��16(�6�   $
��milk��6�   
���   �$	��100��6�   ��6(   �� *	DairyInfo+��5B      �� 5C      $ /Resources/cheese2.jpg��6!   $ UniformToFill=�6F   5E      �� 5F      $��	10,0,10,0q�6   #��[ 6H   $��2��6~   $��Stretch=�6�   $��16(�6�   $�� ��6�   
���   �$	��100��6�   ��6)   �� *
SweetsInfo+��5G      �� 5H      $ /Resources/cake.jpg��6!   $ UniformToFill=�6C   5J      �� 5K      $��	10,0,10,0q�6   $��3��6F   #��[ 6V   $��Stretch=�6�   $��16(�6�   $��snacks��6�   
���   �$	��100��6�   ��6(   �� *	SaltyInfo+��5L      �� 5M      $ /Resources/snacks.jpg��6!   $ UniformToFill=�6E   5O      5Q      5S      5T      