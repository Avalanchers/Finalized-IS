   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5   	       WpfApp1.MainMenu   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp1     5   	     � Title$  MainMenu��5   	   $	��550��6   $	��800��6'    � WindowStartupLocation$ CenterScreen=�64   .��5	      � $��0,0,-22.4,0.4q�6   .+�5
   
   �� $3��-WhatsApp Image 2019-11-08 at 11.24.29 PM.jpeg��6   $��UniformToFill=�6G   $��0,0,-0.4,0.4q�6_   �� 5   
   $��	Main Menu��6   
�������$��50(�67   $��Center=�6E   $��264,54,289,-55.6q�6b   �� 5   
   
������  �� CornerRadius$ 20��6*   $��10,142,30,50.4q�6<   ._�5      �� $��20,20,20,-45.2q�6   .+�5      �� -   5        $��
AddStudent��5   A      BUTTONTEMPLATE#��[  6   $��Add Student��6S   $��215,10,227,10q�6i   ���#545d6a
�������$��18(�6�   $��40��6�    � Triggers 5      :� 5       :� RoutedEvent$ Button.MouseEnter��6'   .[�5      �� .��5   "   �� .��5   &   �� 	 �� To$
 GrayX�65    �� TargetProperty$1 +(Button.Background).(SolidColorBrush.Color)�5   %   5   #   5      5      :� 5      $ 
MouseLeave��6'   .[�5      �� .��5   "   �� .��5   &   �� $ #545d6aX�65   $1 +(Button.Background).(SolidColorBrush.Color)�5   %   5   #   5      5       5"      �� 5#      -   5        $��EditRoom��5#   A   #��[  6   $��	Edit Room��6R   $��215,10,227,10q�6f   ���#545d6a
�������$��18(�6�   $��39��6�    5$      :� 5%      $ Button.MouseEnter��6'   .[�5&      �� .��5'   "   �� .��5(   &   �� $
 GrayX�65   $1 +(Button.Background).(SolidColorBrush.Color)�5)   %   5*   #   5+      5,      :� 5-      $ 
MouseLeave��6'   .[�5.      �� .��5/   "   �� .��50   &   �� $ #545d6aX�65   $1 +(Button.Background).(SolidColorBrush.Color)�51   %   52   #   53      54      56      �� 57      -   5        $��EditStudent��57   A   #��[  6   $��Edit Student��6U   $��215,10,227,10q�6l   ���#545d6a
�������$��18(�6�   $��39��6�    58      :� 59      $ Button.MouseEnter��6'   .[�5:      �� .��5;   "   �� .��5<   &   �� $
 GrayX�65   $1 +(Button.Background).(SolidColorBrush.Color)�5=   %   5>   #   5?      5@      :� 5A      $ 
MouseLeave��6'   .[�5B      �� .��5C   "   �� .��5D   &   �� $ #545d6aX�65   $1 +(Button.Background).(SolidColorBrush.Color)�5E   %   5F   #   5G      5H      5J      �� 5K      -   5        $��DeleteStudent��5K   B   #��[  6   $��Delete Student��6X   $��215,10,227,10q�6q   ���#545d6a
�������$��18(�6�   $��32��6�    5L      :� 5M      $ Button.MouseEnter��6'   .[�5N      �� .��5O   "   �� .��5P   &   �� $
 GrayX�65   $1 +(Button.Background).(SolidColorBrush.Color)�5Q   %   5R   #   5S      5T      :� 5U      $ 
MouseLeave��6'   .[�5V      �� .��5W   "   �� .��5X   &   �� $ #545d6aX�65   $1 +(Button.Background).(SolidColorBrush.Color)�5Y   %   5Z   #   5[      5\      5^      �� 5_      -   5        $��
DeleteRoom��5_   A   #��[  6   $��Delete Room��6T   $��215,10,227,10q�6j   ���#545d6a
�������$��18(�6�   $��37��6�    5`      :� 5a      $ Button.MouseEnter��6'   .[�5b      �� .��5c   "   �� .��5d   &   �� $
 GrayX�65   $1 +(Button.Background).(SolidColorBrush.Color)�5e   %   5f   #   5g      5h      :� 5i      $ 
MouseLeave��6'   .[�5j      �� .��5k   "   �� .��5l   &   �� $ #545d6aX�65   $1 +(Button.Background).(SolidColorBrush.Color)�5m   %   5n   #   5o      5p      5r      �� 5s      -   5        $��btnBack��5s   A   #��[  6   $
��Exit��6h   $��479,20,50,10q�6w   ���#545d6a
�������$��18(�6�   $��32��6�    5t      :� 5u      $ Button.MouseEnter��6'   .[�5v      �� .��5w   "   �� .��5x   &   �� $
 GrayX�65   $1 +(Button.Background).(SolidColorBrush.Color)�5y   %   5z   #   5{      5|      :� 5}      $ 
MouseLeave��6'   .[�5~      �� .��5   "   �� .��5�   &   �� $ #545d6aX�65   $1 +(Button.Background).(SolidColorBrush.Color)�5�   %   5�   #   5�      5�      5�      5�      5�      5�      5�      