   M S B A M L   `   `   `  ����N  JMonitoringLifestyle, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:MonitoringLifestyleMonitoringLifestyle  5      E'clr-namespace:MonitoringLifestyle.ViewsMonitoringLifestyle.Views  5      2    ,MonitoringLifestyle.Views.AccountUserControl   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:MonitoringLifestyle     5      :local1'clr-namespace:MonitoringLifestyle.Views     5        � 	Resources  5
       �� 
TargetType �� Triggers P� Property P� Value �� Property �� Value �� Self �� RelativeSource	 �� Path��%�  '��       'G� �     �� 5   
   " ��6    5      P� 5       �@=�HasError . . �5      ��  �@�ToolTip 5      �� # Z $)	 #(Validation.Errors)[0].ErrorContent�5      5      �� 5   
   " G�6    5      P� 5       �@=�HasError . . �5      ��  �@�ToolTip 5      �� # Z $)	 #(Validation.Errors)[0].ErrorContent�5      5      5      .��5       � $	��400��6   $	��700��6   $��Center=�6$   
 � ColumnDefinitions
 5!   
   �� 5"      $��1* �6   �� 5#      $��1* �6   .+�5%   
   � $	��350��6   
�������$��0��6.    � RowDefinitions 5&      �� 5'      �� 5(      �� 5)      �� 5*      �� 5+      �� 5,      �� 5-      �� 5.      �� 5/      .+�51      �� $��0��6    �� Orientation$ 
Horizontal=�6&   $	��350��6?   $��Right=�6K   .+�52      �� $��	EXISTING ��6   $��24(�6-   $��Arial)�6;   $
��Bold"�6N   �� 53      $
��USER��6   $��24(�6(   $��Arial)�66   $
��Bold"�6I   ���	#FF9E98986[   54      �� 55      $��1��6   {�.  $��22(�67   $��Arial)�6E   $
��Bold"�6X   $��Sign Into FoodBack��6j   �� 56      $��2��6   $"��EMAIL ADDRESS OR USER NUMBER��6%   $��18(�6I   $��Bottom=�6W   �� 57      -   5         ��Name$ emailTextbox��57      $��3��6-   $
��Left=�6:   $	��300��6U   $��Arial)�6�   $��16(�6�   ���	#89C3ADAD��6a   �� *User.EmailAddress+ �� UpdateSourceTrigger$ PropertyChanged=� �� ValidatesOnDataErrors . 6�   �� 58      $��4��6   $��YOUR PASSWORD��6%   $��Bottom=�6:   $��18(�6U   G� 59      -   5         G�Name$ passwordTextbox��59      $��5��64   $
��Left=�6A   $	��300��6\   .   (MonitoringLifestyle.Views.PasswordHelper   BindPassword . $��Arial)�6%  $��16(�68  ���	#89C3ADAD   BoundPassword 6�   �� *User.Password+ �� Mode$ OneWayToSource=�$ PropertyChanged=� . 6F  �� 5:      $��7��6   ���	#FF5A7900$��SIGN IN��6T   
�������$��22(�6y   $	��300��6�   $
��Left=�6�   $��Arial)�6�   ��6"   �� *SignIn+{�6�   �� *User.AllPropertiesValid+5;      � 5<   
   $	��350��6   
�������$��1��6/    5=      �� 5>      $��46 �6    �� 5?      $��46 �6    �� 5@      $��46 �6    .+�5B      �� $��0��6   $ 
Horizontal=�6&   .+�5C      �� $	��NEW��6   $��24(�6'   $��Arial)�65   $
��Bold"�6H   $��0,0,0,10q�6Z   �� 5D      $��36(�6   $��Arial)�6*   $
��Bold"�6=   ���	#FF9E9898$��0,0,0,10q�6f   �� 6z   $� ��6~   �� 6�   $��24(�6�   $
�USER��6�   6�   5E      �� 5F      $��22(�6   $��Arial)�6&   $
��Bold"�69   $��0,0,0,10q�6K   $��1��6]   �� 6k   $�Create ��6o   �� 6�   $�a FoodBack account��6�   6�   �� 5G      $��2��6   ���	#FF5A7900$	��300��69   $
��left=�6E   
�������$��REGISTER NOW��6s   $��22(�6�   $��Arial)�6�   ��6�   �� *
Register+5H      5I      5J      