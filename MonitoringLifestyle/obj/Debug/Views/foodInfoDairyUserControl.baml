   M S B A M L   `   `   `  ����N  JMonitoringLifestyle, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:MonitoringLifestyle.ViewsMonitoringLifestyle.Views  5      8    2MonitoringLifestyle.Views.foodInfoDairyUserControl   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:MonitoringLifestyle.Views     5      U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5        � 	Resources  5
         TextBoxBaseControlTemplate �� 
TargetType ��Name �� CornerRadius ��Name �� Triggers P� Property P� Value �� Value	 �� 
TargetName
 �� Property  ButtonBaseControlTemplate ��Name��%  &	        &	 :    �� 5   
   " ��6=   .R�5      �� $ Bd��5      #��z��5      
���   �#��z��5      $ 7��6E   ._�5      �� $ PART_ContentHost��6   5       5      P� 5       � {� .  . �5      �� # � ��63   $	 Bd��6u   
 � ���� 5      # � ��63   
 � ��5      5      �� 5   
   " ��6<   .R�5      �� $ Bd��5      #��z��5      
���   �#��z��5      $ 70��6E   $��	0,-22,0,0q�6W   ._�5      �� $ PART_ContentHost��6   5      5      5      .��5       �  � RowDefinitions 5!   
   �� 5"      $
��100* �6   �� 5#      $
��100* �6   �� 5$      $
��100* �6   �� 5%      $
��100* �6   �� 5&      $
��100* �6    � ColumnDefinitions 5(   
   �� 5)      $
��265* �6   �� 5*      $
��265* �6   .+�5.   
   �� #��[  6   $��1��6J   $��0��6W   $��Right=�6g   $��65��6�   $��16(�6�   
���   �$��	0,0,236,0q�6�   .��6�   ��5/      �� 50       �� ImageSource$ /Resources/pizza.jpg��6    j� Stretch$ UniformToFill=�6@   .��51   "   52      �� 53   
   #��[  6   $��2��6J   $��0��6W   $��Right=�6g   $��65��6�   $��16(�6�   
���   �$��	0,0,236,0q�6�   .��6�   ��54      �� 55      $ /Resources/lazanya.jpg��6   $ UniformToFill=�6B   .��56   "   57      �� 58   
   #��[  6   $��3��6J   $��0��6W   $��Right=�6g   $��65��6�   $��16(�6�   
���   �$��	0,0,236,0q�6�   .��6�   ��59      �� 5:      $ /Resources/pancake.jpg��6   $ UniformToFill=�6B   .��5;   "   5<      �� 5=   
   #��[  6   $��4��6J   $��0��6W   $��Right=�6g   $��65��6�   $��16(�6�   
���   �$��	0,0,236,0q�6�   .��6�   ��5>      �� 5?      $$ /Resources/bulgariancheese.jpg��6   $ UniformToFill=�6J   .��5@   "   5A      �� 5C   
   #��[  6   $��1��6J   $��1��6W   $��Right=�6g   $��65��6�   $��16(�6�   
���   �$��	0,0,175,0q�6�   .��6�   ��5D      �� 5E      $ /Resources/yogurtt.jpg��6   $ UniformToFill=�6B   .��5F   "   5G      �� 5H   
   #��[  6   $��2��6J   $��1��6W   $��Right=�6g   $��65��6�   $��16(�6�   
���   �$��	0,0,175,0q�6�   .��6�   ��5I      �� 5J      $ /Resources/slmwn.jpg��6   $ UniformToFill=�6@   .��5K   "   5L      �� 5M   
   #��[  6   $��3��6J   $��1��6W   $��Right=�6g   $��65��6�   $��16(�6�   
���   �$��	0,0,175,0q�6�   .��6�   ��5N      �� 5O      $&  /Resources/sweetpotatoquiche.jpg��6   $ UniformToFill=�6L   .��5P   "   5Q      �� 5T   
   #��[  6   $��4��6J   $��1��6W   $��Right=�6g   $��65��6�   $��16(�6�   
���   �$��	0,0,175,0q�6�   .��6�   ��5U      �� 5V      $! /Resources/frenchecrape.jpg��6   $ UniformToFill=�6G   .��5W   "   5X      �� 5^   
   $��36(�6   $��0��6"   $��Arial)�62   $
��Bold"�6E   $��
160,0,0,29q�6W   $
��Left=�6k   $	��192��6�   $��Dairy��6�   �� 5_   
   $��foods��6   $��36(�6!   $��Arial)�6/   $
��Bold"�6B   ���	#FF9E9898$��270,0,192,29q�6k   $��2��6�   �� 5`   
   $
��Left=�6   $��16(�6/   $��	177,0,0,0q�6=   $��2��6P   $
��Wrap=�6]   $��lazagna��6q   $	��Top=�6�   $	��101��6�   $��21��6�   ���	#FF3F9C446�   �� 5a   
   $
��Left=�6   $��16(�6/   $��	177,0,0,0q�6=   $��1��6P   $
��Wrap=�6]   $��pizza��6q   $	��Top=�6~   $	��101��6�   $��21��6�   ���	#FF3F9C446�   �� 5b   
   $
��Left=�6   $��16(�6/   $��	177,0,0,0q�6=   $��3��6P   $
��Wrap=�6]   $��pancakes��6q   $	��Top=�6�   $	��101��6�   $��21��6�   ���	#FF3F9C446�   �� 5c   
   $
��Left=�6   $��16(�6/   $��	186,0,0,0q�6=   $��3��6P   $
��Wrap=�6]   $��sweet potato quiche��6q   $	��Top=�6�   $	��160��6�   $��21��6�   ���	#FF3F9C44$��1��6�   �� 5d   
   $
��Left=�6   $��16(�6/   $��	186,0,0,0q�6=   $��2��6P   $
��Wrap=�6]   $��salmon��6q   $	��Top=�6   $	��101��6�   $��21��6�   ���	#FF3F9C44 J� RenderTransformOrigin$ 0.585,1.358&�6�   $��1��6�   �� 5e   
   $
��Left=�6   $��16(�6/   $��
186,0,0,49q�6=   $��1��6Q   $
��Wrap=�6^   $��yogurt��6r   $	��117��6�   ���	#FF3F9C44$��1��6�   $ 0.101,0.525&�6�   �� 5f   
   $
��Left=�6   $��16(�6/   $��	177,0,0,0q�6=   $��4��6P   $
��Wrap=�6]   $��bulgarian cheese��6q   $	��Top=�6�   $	��149��6�   $��21��6�   ���	#FF3F9C446�   �� 5g   
   $
��Left=�6   $��16(�6/   $��	186,0,0,0q�6=   $��4��6P   $
��Wrap=�6]   $��frenche crape��6q   $	��Top=�6�   $	��101��6�   $��21��6�   ���	#FF3F9C44$��1��6�   �� 5h   
   $��1��6   $
��Left=�6$   $��190,21,0,31q�6?   $��1��6T   $
��Wrap=�6a   $ ��64 calories, 4.7 proteins ��6u   $	��170��6�   �� 5i   
   $��1��6   $
��Left=�6$   $��
186,39,0,0q�6?   $��1��6S   $
��Wrap=�6`   $(��"3 fats, 4.7 carbs , 12 Cholesterol��6t   $	��Top=�6�   $	��170��6�   $��31��6�   �� 5j   
   $
��Left=�6   $��177,21,0,31q�6/   $��4��6D   $
��Wrap=�6Q   $ ��277 calories, 13 proteins ��6e   $	��170��6�   �� 5k   
   $
��Left=�6   $��
177,39,0,0q�6/   $��4��6C   $
��Wrap=�6P   $'��!24 fats, 3 carbs ,144 Cholesterol��6d   $	��Top=�6�   $	��158��6�   $��31��6�   �� 5l   
   $
��Left=�6   $��177,21,0,31q�6/   $��3��6D   $
��Wrap=�6Q   $!��226 calories, 6.4 proteins ��6e   $	��170��6�   �� 5m   
   $
��Left=�6   $��
177,39,0,0q�6/   $��3��6C   $
��Wrap=�6P   $*��$9.7 fats, 28.3 carbs ,59 Cholesterol��6d   $	��Top=�6�   $	��170��6�   $��31��6�   �� 5n   
   $
��Left=�6   $��177,21,0,31q�6/   $��2��6D   $
��Wrap=�6Q   $%��1037.1 calories, 21.3 proteins ��6e   $	��170��6�   �� 5o   
   $
��Left=�6   $��
177,39,0,0q�6/   $��2��6C   $
��Wrap=�6P   $0��*35.4 fats, 158.1 carbs , 101.1 Cholesterol��6d   $	��Top=�6�   $	��170��6�   $��31��6�   �� 5p   
   $
��Left=�6   $��177,21,0,31q�6/   $��1��6D   $
��Wrap=�6Q   $ ��378 calories, 10 proteins ��6e   $	��170��6�   �� 5q   
   $
��Left=�6   $��
177,39,0,0q�6/   $��1��6C   $
��Wrap=�6P   $*��$17.5 fats, 45 carbs , 13 Cholesterol��6d   $	��Top=�6�   $	��170��6�   $��31��6�   �� 5r   
   $��1��6   $
��Left=�6$   $��186,21,0,31q�6?   $��4��6T   $
��Wrap=�6a   $��349 calories, 5 proteins ��6u   $	��170��6�   �� 5s   
   $��1��6   $
��Left=�6$   $��
186,39,0,0q�6?   $��4��6S   $
��Wrap=�6`   $(��"19 fats, 40 carbs , 40 Cholesterol��6t   $	��Top=�6�   $	��170��6�   $��31��6�   �� 5t   
   $��1��6   $
��Left=�6$   $��186,21,0,31q�6?   $��3��6T   $
��Wrap=�6a   $��121 calories, 3 proteins ��6u   $	��170��6�   �� 5u   
   $��1��6   $
��Left=�6$   $��
186,39,0,0q�6?   $��3��6S   $
��Wrap=�6`   $'��!6 fats, 15 carbs , 51 Cholesterol��6t   $	��Top=�6�   $	��170��6�   $��31��6�   �� 5v   
   $��1��6   $
��Left=�6$   $��186,21,0,31q�6?   $��2��6T   $
��Wrap=�6a   $ ��194 calories, 20 proteins ��6u   $	��170��6�   �� 5w   
   $��1��6   $
��Left=�6$   $��
186,39,0,0q�6?   $��2��6S   $
��Wrap=�6`   $'��!12 fats, 0 carbs , 33 Cholesterol��6t   $	��Top=�6�   $	��170��6�   $��31��6�   �� 5x   
   $
��Left=�6   $	��Top=�6R   $	��100��6j   $��0��6v   ��6,   �� *BackWindowCommand+��6�   Z� ��6�   Z� .��5y      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=null]]   Kind$ 	ArrowBack=�6&   $��32��67   $��72��6C   5z      5{      5|      