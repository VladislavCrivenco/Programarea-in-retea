   M S B A M L   `   `   `  ����A  =VCmail, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:VCmailVCmail  5   	       VCmail.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:VCmail     5   	     � Title$  
MainWindow��5   	   $	��720��6   $
��1080��6)   .��5	      �  � RowDefinitions 5
   
   �� 5      $��50 �6   �� 5      .+�5   
   �� $��10q�6    �� Orientation$ 
Horizontal=�6!   .+�5      �� -   5        $��	CreateBtn��5       $��50��6   $��
0, 3, 0, 0q�61   $
��Left=�6E   .��6x   Create6�   �� 5      $��130, 0, 0, 0q�6   $ 
Horizontal=�6/   .+�5      �� -   5        $��SearchTextBox��5   3   $	��300��6   $��3q�6'   63   �� 5      -   5        $��	SearchBtn��5   $   $��50��6   $
��Left=�65   .��6h   Search6p   5      5      � 5   
   -   5        $��ContentGrid��5      $��1��6    � ColumnDefinitions 5      �� 5      $	��200 �6#   �� 5      $	��500 �6#   �� 5      $��* �6#   .+�5      �� -   5        $��
LabelsList��5   '   $��0��6   ��5      �� 5      .R�5      ]� .+�5      �� $��
labelTitle��6t   $
��Left=�6(   $��10q�6?    � Cursor$
 Hand��6K   ��6Y   ��  �� Path$
 Name�6t   �� 5       $��Right=�6(   ��6@   �� $ UndreadMsgNr�6e   5!      5#      5%      �� 5&      -   5        $��MessagesList��5&   '   $��1��6   ��5'      �� 5(      .R�5)      �  5*      �� 5+   "   �� 5,   "    5.      �� 5/   "   $��* �63   �� 50   "   $��7* �63   �� 51   "   $��3* �63   .+�53      A� $��0��55   !   $��0��56   !   
��� ���$��10��58   !   $��10��59   !   y�54   !   �� *UnreadIconVisibility+59   !   �� 5;      $��msgFrom��6�   $��0��6(   $��1��65   $
��Bold"�6E   $
��Wrap=�6W   $��10q�6k   $
 Hand��6w   ��6�   �� *From+6�   �� 5<      $��msgDate��6�   $��0��6(   $��2��65   $
��Wrap=�6F   $��10q�6Z   $
 Hand��6f   ��6t   �� *Date+6�   �� 5=      $��
msgSnippet��6�   $��1��6(   $��1��65   $��CharacterEllipsis=�6E   $
��Wrap=�6f   $��10q�6z   $
 Hand��6�   ��6�   �� *	Snippet+6�   5>      5?      5A       � 5B      -   5        $��ContentFrame��5B   $   $��2��6     � NavigationUIVisibility$ Hidden=�68   5C      5D      5E      