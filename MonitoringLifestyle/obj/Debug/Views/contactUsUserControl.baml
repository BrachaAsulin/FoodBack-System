   M S B A M L   `   `   `  ����N  JMonitoringLifestyle, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:MonitoringLifestyleMonitoringLifestyle  5      4    .MonitoringLifestyle.Views.contactUsUserControl   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      -local!clr-namespace:MonitoringLifestyle  5        � 	Resources  5
       �� 
TargetType �� Triggers P� Property P� Value �� Property �� Value �� Self �� RelativeSource	 �� Path��%�   '��       �� 5   
   " ��6    5      P� 5       �@=�HasError . . �5      ��  �@�ToolTip 5      �� # Z $)	 #(Validation.Errors)[0].ErrorContent�5      5      5      .��5      � -   5        $��GridContact��5      
�������$��	100,0,0,0q�61   
 � RowDefinitions
 5   
   �� 5      $��42 �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $
��1.5* �6   �� 5      $��1* �6    � ColumnDefinitions 5   
   �� 5       $	��53* �6   �� 5!      $
��547* �6   .+�5#   
   �� $��0��6   $
��Left=�6!   $��Bottom=�6<   $��
Contact Us��6W   $��24(�6i   $��Arial)�6w   ���	#FF5A7900$��39��6�   $	��127��6�   $
��Bold"�6�   $��1��6�   '  !MaterialDesignThemes.Wpf.PackIcon  5%   
   $��0��6"   $��1��62   �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=null]]   Kind$ Person=�6?   $��40��6M   $��35��6X   ���	#FF5A7900$��Center=�6{   $
��10,0q�6�   
�������6�   �� 5)   
   $��1��6f   
�������$��5��6�   $��Center=�6�   $	��Top=�6�   ���	#FFE7E8EC��6   �� *	ContactUs+{�6/   �� *" UserToContact.AllPropertiesValid+.��5*        $
 send=�6&   $	��150��62   $��20��6>   ���	#FF5A79006J   5+        5-   
   $��0��6"   $��4��62   $ 
ArrowRight=�6?   $��40��6Q   $��35��6\   ���	#FF5A7900$��Center=�6   $
��10,0q�6�     50   
   $��0��6"   $��2��62   $ 	Telephone=�6?   $��40��6P   $��35��6[   ���	#FF5A7900$��Center=�6~   $
��10,0q�6�     51   
   $��0��6"   $��3��62   $ Email=�6?   $��40��6L   $��35��6W   ���	#FF5A7900$
��10,0q�6z   $��Center=�6�   �� 52   
   $��1��6   $
��Left=�6#   $��35��6>   $��1��6J    �� TextWrapping$
 Wrap=�6W   $	��Top=�6k   $	��501��6�   ���	#FFABADB3$��16(�6�      WatermarkNameTextbox#��[  6�   �� 53   
   $��1��6   $
��Left=�6"   $��35��6=   $��2��6I   $
 Wrap=�6V   $	��Top=�6j   $	��501��6�   ���	#FFABADB3$��16(�6�     WatermarkPhoneNumberTextbox#��[ 6�   �� 54   
   $��1��6   $
��Left=�6"   $��35��6=   $��3��6I   $
 Wrap=�6V   $	��Top=�6j   $	��501��6�   ���	#FFABADB3$��16(�6�      WatermarkEmailAddressTextbox#��[ 6�   �� 55   
   $��1��6   $
��Left=�6"   $��69��6=   $��4��6I   $
 Wrap=�6V   $	��Top=�6j   $	��501��6�   ���	#FFABADB3$��16(�6�     WatermarkMessageTextbox#��[ 6�   56      57      