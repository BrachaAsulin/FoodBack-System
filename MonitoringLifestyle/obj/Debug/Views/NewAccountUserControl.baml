   M S B A M L   `   `   `  ����N  JMonitoringLifestyle, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:MonitoringLifestyleMonitoringLifestyle  5      E'clr-namespace:MonitoringLifestyle.ViewsMonitoringLifestyle.Views  5      5    /MonitoringLifestyle.Views.NewAccountUserControl   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:MonitoringLifestyle     5      :local1'clr-namespace:MonitoringLifestyle.Views     5        � 	Resources  5
       �� 
TargetType �� Triggers P� Property P� Value �� Property �� Value �� Self �� RelativeSource	 �� Path   TextBoxBaseControlTemplate
 �� 
TargetType ��Name �� CornerRadius ��Name �� Triggers �� 
TargetName  PasswordBoxControlTemplate  ButtonBaseControlTemplate ��Name��%�  '��       'G� �     &	  �    &	 �    &	 �    �� 5   
   " ��6    5      P� 5       �@=�HasError . . �5      ��  �@�ToolTip 5      �� # Z $)	 #(Validation.Errors)[0].ErrorContent�5      5      �� 5   
   " G�6    5      P� 5       �@=�HasError . . �5      ��  �@�ToolTip 5      �� # Z $)	 #(Validation.Errors)[0].ErrorContent�5      5      �� 5   
   "
 ��6=   .R�5       �� $ Bd��5!      #��z��5       
���   �#��z��5"      $ 7��6E   ._�5#      �� $ PART_ContentHost��6   5$       5%      P� 5&       � {� .  . �5'      �� # � ��63   $ Bd��6u    � ���� 5(      # � ��63    � ��5)      5+      �� 5,   
   "
 G�6=   .R�5-      �� $ Bd��5.      #��z��5-      
���   �#��z��5/      $ 7��6E   ._�50      �� $ PART_ContentHost��6   51       52      P� 53       � {� .  . �54      �� # � ��63   $ Bd��6u    � ���� 55      # � ��63    � ��56      58      �� 59   
   "
 ��6<   .R�5:      �� $ Bd��5;      #��z��5:      
���   �#��z��5<      $ 7��6E   ._�5=      �� $ PART_ContentHost��6   5>      5?      5@      .��5A      � 
������� � RowDefinitions 5B   
   �� 5C      $��1* �6   �� 5D      $��1* �6   �� 5E      $��1* �6   �� 5F      $��1* �6   �� 5G      $��1* �6   �� 5H      $��1* �6   �� 5I      $��1* �6   �� 5J      $��2* �6   .+�5L   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   .+�5M      �� $��
First Name��6   $	��150��6*   $��24(�66   $��Center=�6D   $��Arial)�6_   
�������$��20,0,0,0q�6�   �� 5N      #��[  6}   $	��500��6�   $��25��6�   $��20(�6�   $��10q�6�   $��Arial)�6�   ��6   �� *NewAccount.FirstName+ �� UpdateSourceTrigger$ PropertyChanged=� �� ValidatesOnDataErrors . 6�   5O      �� 5P   
   $��1��6   $ 
Horizontal=�6"   .+�5Q      �� $��	Last Name��6   $	��150��6)   $��24(�65   $��Center=�6C   $��Arial)�6^   
�������$��20,0,0,0q�6�   �� 5R      #��[  6|   $	��500��6�   $��25��6�   $��10q�6�   $��20(�6�   $��Arial)�6�   ��6   �� *NewAccount.LastName+$ PropertyChanged=� . 6�   5S      �� 5T   
   $��2��6   $ 
Horizontal=�6"   .+�5U      �� $��Email��6   $	��150��6%   $��24(�61   $��Center=�6?   $��Arial)�6Z   
�������$��20,0,0,0q�6   �� 5V      #��[  6�   $	��500��6�   $��25��6�   $��10q�6�   $��20(�6�   $��Arial)�6�   ��6   �� *NewAccount.EmailAddress+$ PropertyChanged=� . 6�   5W      �� 5X   
   $��3��6   $ 
Horizontal=�6"   .+�5Y      �� $��Password��6   $	��150��6(   $��24(�64   $��Center=�6B   $��Arial)�6]   
�������$��20,0,0,0q�6�   G� 5Z      .   (MonitoringLifestyle.Views.PasswordHelper   BindPassword . #��[ 6�   $	��500��6  $��25��6   $��10q�6,  $��20(�68  $��Arial)�6F     BoundPassword 6D   �� *NewAccount.Password+$ PropertyChanged=� �� Mode$ OneWayToSource=� . 6F  5[      �� 5\   
   $��4��6   $ 
Horizontal=�6"   .+�5]      �� $��Date Of Birth��6   $��24(�6-   $��Center=�6;   $��Arial)�6V   
�������$	��150��6{   $��20,0,0,0q�6�   �� 5^        WatermarkTextbox#��[ 6   $��10q�6B   $	��500��6N   $��25��6Z   $��20(�6g   $��Arial)�6u   5_      �� 5`   
   $��5��6   $ 
Horizontal=�6"   .+�5a      �� $��Height��6   $	��150��6&   $��24(�62   $��Center=�6@   $��Arial)�6[   
�������$��20,0,0,0q�6�   �� 5b      #��[  6z   $	��500��6�   $��25��6�   $��10q�6�   $��20(�6�   ���	#FF080808$��Arial)�6�   ��6   �� *NewAccount.Height+$ PropertyChanged=� . 6�   5c      �� 5d   
   $��6��6   $ 
Horizontal=�6"   .+�5e      �� $��Weight��6   $	��150��6&   $��24(�62   $��Center=�6@   $��Arial)�6[   
�������$��20,0,0,0q�6�   �� 5f      #��[  6z   $	��500��6�   $��25��6�   $��10q�6�   $��20(�6�   ���	#FF080808$��Arial)�6�   ��6   �� *NewAccount.Weight+$ PropertyChanged=� . 6�   5g      �� 5h   
   $��7��6e   $��Right=�6r   $	��350��6�   $��50��6�   $��20(�6�   ���	#FF5A7900$ ��GREAT, REGISTER MY ACCOUNT��6�   
�������$��	0,0,100,0q�6  ��6   �� *registerNow+{�61   �� *NewAccount.AllPropertiesValid+5i      5k      5m      