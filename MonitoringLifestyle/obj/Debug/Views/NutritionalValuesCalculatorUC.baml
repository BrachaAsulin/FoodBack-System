   M S B A M L   `   `   `  ����N  JMonitoringLifestyle, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:MonitoringLifestyleMonitoringLifestyle  5      E'clr-namespace:MonitoringLifestyle.ViewsMonitoringLifestyle.Views  5      =    7MonitoringLifestyle.Views.NutritionalValuesCalculatorUC   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:MonitoringLifestyle     5      :local1'clr-namespace:MonitoringLifestyle.Views     5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      h dMicrosoft.Expression.Interactions, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bei9http://schemas.microsoft.com/expression/2010/interactions  5	      U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5
      .��5      � -   5          �Name$  calculatorGrid��5      
������� � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $
��0.5* �6   �� 5      $
��0.5* �6   �� 5      $
��0.5* �6   �� 5      $
��0.5* �6   �� 5      $
��0.5* �6    � 	Resources 5   
    �� Source�� 5      $D >/MonitoringLifestyle;component/Styles/AutoComplete.Styles.xaml?�6!   %    .+�5   
   �� $$��Nutritional Values Calculator ��6   $��36(�6:   $��Arial)�6H   $
��Bold"�6[   $��Center=�6m   ���	#FF5A79006�   �� 5   
   $��SELECT A DESIRABLE FOOD��6   $��Center=�63   $��24(�6P   $��1��6^   $
��Wrap=�6k   $��Bottom=�6   $��Arial)�6�   ���	#FF2625236�   �� 5    
   $��22(�6   $
��Left=�6#   $��	415,0,0,0q�6>   $��4��6R   $
��Wrap=�6_   $	��Top=�6s   ���	#FFD62A9F$
��Bold"�6�   $��Arial)�6�   
Calories6�   �� 5!   
   $��22(�6   $
��Left=�6#   $��	415,0,0,0q�6>   $��5��6R   $
��Wrap=�6_   $	��Top=�6s   ���	#FFD62A9F$
��Bold"�6�   $��Arial)�6�   Fats6�   �� 5"   
   $��22(�6   $
��Left=�6#   $��	415,0,0,0q�6>   $��6��6R   $
��Wrap=�6_   $	��Top=�6s   ���	#FFD62A9F$��Arial)�6�   $
��Bold"�6�   Fibers6�   �� 5#   
   $��22(�6   $
��Left=�6#   $��	415,0,0,0q�6>   $��7��6R   $
��Wrap=�6_   $	��Top=�6s   ���	#FFD62A9F$��Arial)�6�   $
��Bold"�6�   
Proteins6�   �� 5$   
   $��22(�6   $
��Left=�6#   $��	415,0,0,0q�6?   $��8��6R   $
��Wrap=�6_   $	��Top=�6s   ���	#FFD62A9F$
��Bold"�6�   $��Arial)�6�   Sugars6�   ,   &MonitoringLifestyle.Views.AutoComplete  5%   
   -   5          Name$ 	autoFoods��5%       �� SelectedValuePath$ FoodID��61    �� DisplayMemberPath$
 Name��6L   $��2��6e   $��10q�5&         Delay$	 500��6'      AutoCompleteComboBox#��[  63   $	��520��6a   $��50��6m    �� SelectedValue 6y   �� *FoodIdSelected+.  (System.Windows.Interactivity.Interaction	   Triggers	 5'      /  )System.Windows.Interactivity.EventTrigger  5(      
   	EventName$
 PatternChanged��6!   .  (System.Windows.Interactivity.TriggerBase   Actions. 5)      >  8Microsoft.Expression.Interactivity.Core.CallMethodAction     
MethodName$ autoFoods_PatternChanged��6C      TargetObject 6*   �� 6C   5*      5,      �� 5-   
   -   5         ��Name$ caloriesTextbox��5-      $��Center=�6+   $��23��6H   $��	120,0,0,0q�6T   $��4��6g    �� TextWrapping$
 Wrap=�6t   $	��Top=�6�   $	��120��6�   ��6�   �� *
calories+6�   �� 5.   
   -   5        $ sugarTextbox��5.      $��Center=�6(   $��23��6E   $��	120,0,0,0q�6Q   $��8��6d   $
 Wrap=�6q   $	��Top=�6�   $	��120��6�   ��6�   �� *sugar+6�   �� 5/   
   -   5        $ proteinsTextbox��5/      $��Center=�6+   $��23��6H   $��	120,0,0,0q�6T   $��7��6g   $
 Wrap=�6t   $	��Top=�6�   $	��120��6�   ��6�   �� *
proteins+6�   �� 50   
   -   5        $ carbsTextbox��50      $��Center=�6(   $��23��6E   $��	120,0,0,0q�6Q   $��6��6d   $
 Wrap=�6q   $	��Top=�6�   $	��120��6�   ��6�   �� *fibers+6�   �� 51   
   -   5        $ fatsTextbox��51      $��Center=�6'   $��23��6D   $��	120,0,0,0q�6P   $��5��6c   $
 Wrap=�6p   $	��Top=�6�   $	��120��6�   ��6�   �� *fats+6�   �� 52   
   $��click to see the result��65   $��Center=�6W   $��3��6t   $	��Top=�6�   $��20(�6�   $	��250��6�   $��38��6�   ��6   �� *NutrionalValues+6�   55      56      