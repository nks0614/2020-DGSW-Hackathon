   M S B A M L   `   `   `  ����F  BDGM_windows, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:DGM_windowsDGM_windows  5   	       DGM_windows.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:DGM_windows     5   	   -   5        $��MainWindows��5   	     � Title$  DGSW_Manager��5   	   $	��562��6   $
��1000��6+    � WindowStyle$
 None=�5	   	    � AllowsTransparency .  � 
ResizeMode$ NoResize=�5   	   
������  � Topmost .  � ShowInTaskbar .   � WindowStartupLocation$ Manual=�5   	    � Icon$ ./Image/manager.png��6(    � Left$ 0��5   	   
	 � Top$	 0��5   	   .��5      � $	��562��6   $
��1000��6   .+�5   
   �� 
�������$	��562��6!   $
��1000��6.   
 �� RadiusX$
 50��6;    �� RadiusY$ 50��6H   �� 5   
    K� ZIndex$ 2��6   
������ $	��562��68   $
��1000��6E   $
 50��6R   $ 50��6_   �� 5   
   $��DGSW MANAGER��6   $��35(�6'   ���#707070$
��Bold"�6J   $��38 7 0 0q�6\   $	��Top=�6n   $
��Left=�6�   �� 5   
   $=��7대소고 생활이 당신의 삶에서 가취있기를��6   $��18(�60   ���#707070$
��Bold"�6S   $��	38 56 0 0q�6e   $	��Top=�6x   $
��Left=�6�   �� 5   
   $��0 41 0 0q�6   $	��Top=�6'   $��Center=�6?    �� Orientation$ Vertical=�6\   .+�5      �� $��오늘의 날씨��6   $��18(�6%   ���#707070$
��Bold"�6H   $	��Top=�6Z   $��Center=�6r   �� 5      -   5        $��WeatherImage��5      $��./Image/night.png��6(   $	��131��6C   $	��131��6O   $	��Top=�6\   $��Center=�6t   �� 5       -   5        $��WeatherTemp��5       $��30˚C��6'   $��18(�66   ���#707070$	��Top=�6Y   $��Center=�6q   �� 5!      -   5        $��WeatherContent��5!      $E��?날씨가 어두워요!! 웨어울프가 깨어나기 좋아요��6*   $��17(�6N   ���#707070$	��Top=�6q   $��Center=�6�   5"      �� 5$   
   -   5        $��	TodayDate��5$      $��----년 --월 --일��6!   $��22(�69   ���#292929$
��Bold"�6\   $��
728 32 0 0q�6n   $	��Top=�6�   $
��Left=�6�   �� 5&   
   $��756 111 0 0q�6   $	��Top=�6*   $
��Left=�6B   $ Vertical=�6]   .+�5'      �� $ 
Horizontal=�6   $��Center=�62   .+�5(      �� $��오늘의 일정��6   $��22(�6)   ���#292929$
��Bold"�6L   $	��Top=�6^   $��Center=�6v   5)      � 5*      .+�5+      �� $	��168��6   $��64��6(   ���#7D7D7D$
 20��6C   $ 20��6P   $��Center=�6]   $��Center=�6x   �� 5,      -   5        $��ScheduleContent��5,      
������ 
������ $'��!오늘의 일정은 없습니다.��6d   $��Center=�6y    �� TextWrapping$ WrapWithOverflow=�6�   $��10(�6�   $	��140��6�   
�������$
��Bold"�6�   $��Center=�6�   $��Center=�6  5-      5.      �� 5/   
   -   5        $ 3��5/      $��./Image/add.png��6!   $��20��6:   $��20��6E   $��906 121 0 0q�6Q   $	��Top=�6f   $
��Left=�6~   6�   �� 50   
   -   5        $ 3��50      $��756 151 0 0q�6%   $	��168��6:   $��64��6F   
������ $
 20��6e   $ 20��6r   $	��Top=�6   $
��Left=�6�   6�   � 52   
   -	   5        $ 3��52      $	��100��6    $��50��6-   $	��Top=�68   $
��Left=�6P   $��
25 370 0 0q�6�   .+�53      �� $��./Image/left-arrow.png��6   $��30��64   $��30��6?   54      � 56   
   -
   5        $ 3��56      $	��100��6    $��50��6-   $	��Top=�68   $��Right=�6P   $��
0 370 25 0q�6�   .+�57      �� $��./Image/right-arrow.png��6   $��30��65   $��30��6@   58      � 5:   
   $��	0 311 0 0q�6   $	��215��6"   $
��1000��6/   $	��Top=�6<    � ColumnDefinitions 5;      �� 5<      $��1* �6#   �� 5=      $��5* �6#   �� 5>      $��5* �6#   �� 5?      $��5* �6#   �� 5@      $��1* �6#   .+�5C      � $��1��6   $	��215��6#   $	��215��6/   $	��Top=�6<   $��Center=�6T   .+�5D      �� $	��215��6   $	��215��6(   
���   �$
 20��6B   $ 20��6O   $	��Top=�6\   $
��Left=�6t   �� 5E      $��아침��6   $��Center=�6%   $��23(�6I   $��64��6W   
�������$
��Bold"�6u   $	��Top=�6�   $��Center=�6�   �� 5F      -   5        $��MealBreakfast��5F      $��푸팟퐁 커리��6/   $ WrapWithOverflow=�6=   
������ 
������ $��Center=�6�   $��15(�6�   $	��200��6�   
�������$
��Bold"�6�   $��0 46 0 0q�6�   $	��Top=�6  $��Center=�6  5G      � 5I      $��2��6   $	��215��6#   $	��215��6/   $	��Top=�6<   $��Center=�6T   .+�5J      �� $	��215��6   $	��215��6(   
���   �$
 20��6B   $ 20��6O   $	��Top=�6\   $
��Left=�6t   �� 5K      $��점심��6   $��Center=�6%   $��23(�6I   $��64��6W   
�������$
��Bold"�6u   $	��Top=�6�   $��Center=�6�   �� 5L      -   5        $��	MealLunch��5L      $��푸팟퐁 커리��6+   $ WrapWithOverflow=�69   
������ 
������ $��Center=�6�   $��15(�6�   $	��200��6�   
�������$
��Bold"�6�   $��0 46 0 0q�6�   $	��Top=�6  $��Center=�6  5M      � 5O      $��3��6   $	��215��6#   $	��215��6/   $	��Top=�6<   $��Center=�6T   .+�5P      �� $	��215��6   $	��215��6(   
���   �$
 20��6B   $ 20��6O   $	��Top=�6\   $
��Left=�6t   �� 5Q      $��저녁��6   $��Center=�6%   $��23(�6I   $��64��6W   
�������$
��Bold"�6u   $	��Top=�6�   $��Center=�6�   �� 5R      -   5        $��
MealDinner��5R      $��푸팟퐁 커리��6,   $ WrapWithOverflow=�6:   
������ 
������ $��Center=�6�   $��15(�6�   $	��200��6�   
�������$
��Bold"�6�   $��0 46 0 0q�6�   $	��Top=�6  $��Center=�6  5S      5U      5V      5W      