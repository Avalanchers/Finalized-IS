   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5   	       WpfApp1.DeleteStudent   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp1     5   	     � Title$  DeleteStudent��5   	   $	��600��6   $	��800��6,    � WindowStartupLocation$ CenterScreen=�69   .��5	      � .+�5
   
   �� $3��-WhatsApp Image 2019-11-08 at 11.24.29 PM.jpeg��6   $��UniformToFill=�6G   $��0,0,-0.4,0.4q�6_   �� 5   
   
������  �� CornerRadius$ 20��6*   $��20q�6<   ._�5      �� $��10q�6   .+�5      �� $��Delete Student��6   
�������$��25(�6D   $��Center=�6R   �� 5      6   �� 5      $��
Student ID��6   
�������6-   �� 5      -   5        $��txtStudentID��5      ���#545d6a
�������$��18(�6V   $��0,0,370.6,0q�6d   6y   �� 5      $��
First Name��6   
�������6-   �� 5      -   5        $��txtFirstname��5      ���#545d6a
�������$��18(�6V   $��0,0,370.6,0q�6d   6y   �� 5      $��	Last Name��6   
�������6,   �� 5      -   5        $��txtLastname��5      ���#545d6a
�������$��18(�6U   $��0,0,370.6,0q�6c   6x   �� 5      $��E-mail��6   
�������6)   �� 5      -   5        $��txtEmail��5      ���#545d6a
�������$��18(�6R   $��0,0,370.6,0q�6`   6u   �� 5      $��Faculty Name��6   
�������6/   �� 5      -   5        $��txtFacultyname��5      ���#545d6a
�������$��18(�6X   $��0,0,370.6,0q�6f   6{   � 5      $	��200��6   $��
0,0,-0.4,0q�6$   .+�5      �� -   5         ��Name$ 
DelStudent��5   E      BUTTONTEMPLATE#��[  6   $��Delete��6Z   $��362,97,205,68q�6k   ���#545d6a
�������$��18(�6�    � Triggers 5      :� 5       :� RoutedEvent$ UIElement.MouseEnter��6+   .[�5   "   �� .��5   &   �� .��5    *   �� 	 �� To$
 GrayX�69    �� TargetProperty$2 ,(Control.Background).(SolidColorBrush.Color)�5!   %   5"   '   5#   #   5$      :� 5%      $ UIElement.MouseLeave��6+   .[�5&   "   �� .��5'   &   �� .��5(   *   �� $ #545d6aX�69   $2 ,(Control.Background).(SolidColorBrush.Color)�5)   %   5*   '   5+   #   5,      5.      �� 5/      -   5        $ CancelDeleteStudent��5/   E   #��[  6   $��Cancel��6c   $��554,97,10,67q�6t   ���#545d6a
�������$��18(�6�    50      :� 51      $ Button.MouseEnter��6+   .[�52   "   �� .��53   &   �� .��54   *   �� $
 GrayX�69   $1 +(Button.Background).(SolidColorBrush.Color)�55   %   56   '   57   #   58      :� 59      $ 
MouseLeave��6+   .[�5:   "   �� .��5;   &   �� .��5<   *   �� $ #545d6aX�69   $1 +(Button.Background).(SolidColorBrush.Color)�5=   %   5>   '   5?   #   5@      5B      5C      5D      5E      5F      5G      