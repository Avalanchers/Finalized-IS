   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5   	       WpfApp1.Login   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp1     5   	     � Title$  LoginScreen��5   	   $��300.1��6   $	��400��6+   $��14(�68   ���#04c852 � WindowStartupLocation$ CenterScreen=�6[   .��5	      � .+�5
   
   �� $3��-WhatsApp Image 2019-11-08 at 11.24.29 PM.jpeg��6   $��UniformToFill=�6G   $��0,0,-0.4,0.4q�6_   �� 5   
   
������  �� CornerRadius$ 20��6*   $��20q�6<   ._�5      �� $��20q�6   .+�5      �� $��Login��6   
�������$��25(�6;   $��Center=�6I   �� 5      6   �� 5      $��Username��6   
�������6+   �� 5      -   5        $��txtUsername��5      ���#545d6a
�������$��18(�6U   6c   �� 5      $��Password��6   
�������6+   G� 5      -   5        $��txtPassword��5      ���#454d6a
�������$��18(�6Y   �� 5      �� 5      -   5        $��	btnSubmit��5   A      BUTTONTEMPLATE#��[  6   $��Submit��6j   $��60,50,53.6,10q�6{   ���#545d6a
�������$��18(�6�   $��40��6�    � Triggers 5      :� 5       :� RoutedEvent$ Button.MouseEnter��6'   .[�5      �� .��5   "   �� .��5   &   �� 	 �� To$
 GrayX�65    �� TargetProperty$1 +(Button.Background).(SolidColorBrush.Color)�5   %   5   #   5      5      :� 5      $ 
MouseLeave��6'   .[�5      �� .��5    "   �� .��5!   &   �� $ #545d6aX�65   $1 +(Button.Background).(SolidColorBrush.Color)�5"   %   5#   #   5$      5%      5'      5)      5*      5+      5,      