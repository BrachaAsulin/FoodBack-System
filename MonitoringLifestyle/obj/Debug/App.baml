   M S B A M L   `   `   `  ����N  JMonitoringLifestyle, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:MonitoringLifestyleMonitoringLifestyle  5      O,clr-namespace:MonitoringLifestyle.ConvertersMonitoringLifestyle.Converters  5          MonitoringLifestyle.App   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      3local!clr-namespace:MonitoringLifestyle     5      C
converters,clr-namespace:MonitoringLifestyle.Converters     5        �� 	Resources  5       �� MergedDictionaries �� Source>   8MonitoringLifestyle.Converters.boolToVisibilityConverter   InputToVisibility  WatermarkTextbox �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius `� 	Converter	 �� ElementName
 �� Path ��Name �� UpdateSourceTrigger �� ValidatesOnDataErrors  WatermarkNameTextbox  WatermarkPhoneNumberTextbox   WatermarkEmailAddressTextbox  WatermarkMessageTextbox�� 5   
    5	      �� 5
      $e _pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Light.xaml?�6%   �� 5      $h bpack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Defaults.xaml?�6%   �� 5      $u opack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.green.xaml?�6%   �� 5      $u opack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Accent/MaterialDesignColor.indigo.xaml?�6%   %�  &	        &	      7   &	 `    7   &	 �    7   &	 �    7   &	 ;	    7     5   
   6/   �� 5   
   " ��6)   .�5      ��  � ��
 �   �6,   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   #��z��5   !   #��z��5   !   $ 7��5   !   ._�5      � .+�5      �� $��DD / MM / YY��6(   y�5   "   `� 5   &   8   .1�5    *   �� $	 	inputText��62   $
 Text.IsEmpty�6J   �� 5!   *   $	 	inputText��62   $
 	IsFocused�6J   5"   '   5$      �� 5%      $ 	inputText��6&   
������ ��6R   �� *NewAccount.DateOfBirth+$ PropertyChanged=� . 5&      5'      5(      5*      5+      �� 5,   
   " ��6-   .�5-      ��  � ��
 �����6,   �� 5.       � �� 5/      �� 50      " ��6&   .R�51      �� #��z��6!   #��z��52   !   #��z��53   !   $ 7��54   !   ._�57      � .+�58   "   �� $
��Name��6,   y�59   &   `� 5:   *   8   .1�5;   .   �� $	 	inputText��66   $
 Text.IsEmpty�6N   �� 5<   .   $	 	inputText��66   $
 	IsFocused�6N   5=   +   5?   #   �� 5@   "   $ 	inputText��6*   
������ ��6V   �� *UserToContact.Name+$ PropertyChanged=� . 5A      5B      5C      5E      5F      �� 5G   
   " ��64   .�5H      ��  � ��
 �����6,   �� 5K       � �� 5L      �� 5M      " ��6&   .R�5N      �� #��z��6!   #��z��5O   !   #��z��5P   !   $ 7��5Q   !   ._�5T      � .+�5U   "   �� $��Phone Number��6,   y�5V   &   `� 5W   *   8   .1�5X   .   �� $	 	inputText��66   $
 Text.IsEmpty�6N   �� 5Y   .   $	 	inputText��66   $
 	IsFocused�6N   5Z   +   5\   #   �� 5]   "   $ 	inputText��6*   
������ ��6V   �� *UserToContact.PhoneNumber+$ PropertyChanged=� . 5^      5_      5`      5b      5c      �� 5d   
   " ��65   .�5e      ��  � ��
 �����6,   �� 5h       � �� 5i      �� 5j      " ��6&   .R�5k      �� #��z��6!   #��z��5l   !   #��z��5m   !   $ 7��5n   !   ._�5q      � .+�5r   "   �� $��Email��6,   y�5s   &   `� 5t   *   8   .1�5u   .   �� $	 	inputText��66   $
 Text.IsEmpty�6N   �� 5v   .   $	 	inputText��66   $
 	IsFocused�6N   5w   +   5y   #   �� 5z   "   $ 	inputText��6*   
������ ��6V   �� *UserToContact.EmailAddress+$ PropertyChanged=� . 5{      5|      5}      5      5�      �� 5�   
   " ��60   .�5�      ��  � ��
 �����6,   �� 5�       � �� 5�      �� 5�      " ��6&   .R�5�      �� #��z��6!   #��z��5�   !   #��z��5�   !   $ 7��5�   !   ._�5�      � .+�5�   "   �� $��Message��6,   y�5�   &   `� 5�   *   8   .1�5�   .   �� $	 	inputText��66   $
 Text.IsEmpty�6N   �� 5�   .   $	 	inputText��66   $
 	IsFocused�6N   5�   +   5�   #   �� 5�   "   $ 	inputText��6*   
������ ��6V   �� *UserToContact.Message+$ PropertyChanged=� . 5�      5�      5�      5�      5�      5�      5�      