   M S B A M L   `   `   `  ����F  BDGM_windows, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:DGM_windowsDGM_windows  5   	       DGM_windows.ScheduleView   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:DGM_windows     5   	   -   5        $��ScheduleViews��5	   	     � Title$  ScheduleView��5   	   $	��600��5	      $	��400��6+    � WindowStyle$
 None=�5
   	    � AllowsTransparency .  � 
ResizeMode$ NoResize=�5   	   
������  � Topmost .  � ShowInTaskbar .  .��5      � .+�5   
   �� 
�������
���   �$	��600��6/   $	��400��6<    �� RadiusX$ 10��6H    �� RadiusY$ 10��6U   �� 5   
   -   5         K� ZIndex$ 2��5      
������ 
������ $	��600��6M   $	��400��6Z   $ 10��6f   $ 10��6s   6�   � 5   
   $ 3��6   $��0 10 0 0q�6    $	��380��62   $	��580��6>   $��Center=�6K   $	��Top=�6h   	 � RowDefinitions	 5      �� 5      $��30 �6    �� 5      $��10 �6    �� 5      $��1* �6    �� 5      $��10 �6    �� 5      $��30 �6    .+�5      � $��0��6   .+�5      �� 
�������
���   �$ 5��68   $ 5��6D   (  "System.Windows.Controls.DatePicker  5      -   5        $��
SelectDate��5      $��12(�6d   $ 1��6r   $��Center=�6�   $	��380��6�   $��30��6�   $��Center=�6�   
������ 6�   5      � 5      $��2��6   .+�5      �� 
������ !
 �� IsDeferredScrollingEnabled
 . $��Hidden=�6Z   $��Hidden=�6   .��5       �� -   5        $��ScheduleViewContent��5    !    �� Orientation$ Vertical=�6<   
������ 6�   5!      5"      � 5#      $��4��6   .+�5$      �� -   5        $��CloseButton��5$      
�������
���   �$ 5��6K   $ 5��6W   6c   �� 5%      $��닫기��6   $��Center=�6%   $��Center=�6B   $
��Bold"�6]   5&      5'      5(      5)      