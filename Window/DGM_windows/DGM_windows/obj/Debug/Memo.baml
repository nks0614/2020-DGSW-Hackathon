   M S B A M L   `   `   `  ����F  BDGM_windows, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:DGM_windowsDGM_windows  5   	       DGM_windows.Memo   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:DGM_windows     5   	   -   5        $��Memos��5	   	     � Title$
  Memo��5   	   $	��200��6   $	��400��6#    � WindowStyle$
 None=�5
   	    � AllowsTransparency .  � 
ResizeMode$ NoResize=�5   	   
������  � Topmost .  � ShowInTaskbar .  .��5      � .+�5   
   �� -   5        
�������
���   �$	��200��5   /   $	��400��6<    �� RadiusX$ 10��6H    �� RadiusY$ 10��6U   6�   �� 5   
   -   5        $��id��5      $��0��6   $y�Hidden=�6&   � 5   
   $��0 10 0 0q�6   $	��380��6!   $	��180��6-   $��Center=�6:   $	��Top=�6W    � RowDefinitions 5      �� 5      $	��120 �6    �� 5      $��30 �6    �� 5      $��30 �6    .+�5      �� -   5        $��SaveDescription��5   D   $��20(�6   	 �� TextWrapping$	 WrapWithOverflow=�6$   $��0��6[   $ ��일정을 입력하세요.��6h   
�������
���   �6�   � 5      $��1��6   .+�5      �� 
 K� ZIndex$
 2��6   
������ $��30��6@   $	��351��6L   $��Center=�6X   $
��Left=�6s   
������ 6�   (  "System.Windows.Controls.DatePicker  5      -   5        $��SaveDate��5      $��12(�6-   $
 1��6;   $��Center=�6L   $	��380��6g   $��30��6s   $��Center=�6   
������ 6�   5      � 5      $��2��6    � ColumnDefinitions 5      �� 5      $��1* �6'   �� 5       $��4 �6'   �� 5!      $��1* �6'   .+�5#      � $��0��6   .+�5$      �� -   5        $��
SaveButton��5$       
�������
���   �$ 5��6N   $ 5��6Z   6f   �� 5%      -   5        $��SaveButtonText��5%      $��저장��62   $��Center=�6?   $��Center=�6\   $
��Bold"�6w   5&      � 5'      $��2��6   .+�5(      �� -   5        $��DeleteButton��5(       
�������
���   �$ 5��6P   $ 5��6\   6h   �� 5)      $��삭제��6   $��Center=�6)   $��Center=�6F   $
��Bold"�6a   5*      5+      5,      5-      5.      