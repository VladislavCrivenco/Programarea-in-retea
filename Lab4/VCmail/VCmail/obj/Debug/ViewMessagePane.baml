   M S B A M L   `   `   `  ����A  =VCmail, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:VCmailVCmail  5          VCmail.ViewMessagePane   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      &localclr-namespace:VCmail     5        N� Title$  ViewMessagePane��5	       N� ShowsNavigationUI .  .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��2* �6   �� 5      $��* �6   �� 5      $��8* �6   .+�5   
   �� $��0��6   $��10q�6!   $��15(�6-   $��DemiBold"�6;   ��6Q   ��  �� Path$ Subject��� 5   
   $��1��6   $��10q�6"   .+�5      ]� ��.  .+�5      �� $
��Left=�6   $
��Bold"�62   $
��From��6D   $��15(�6P    �� Padding$ 0,0,15,0q�6^   �� 5      $
��Left=�6   $��15(�6M   ��62   �� $
 From�6M   �� 5      $��Right=�6   $��10q�63   $��15(�6Z   ��6?   �� $
 Date�6Z   5      ]� 5      .+�5      �� $
��Left=�6   $
��Bold"�62   $��To��6D   $��15(�6N   $ 0,0,15,0q�6\   �� 5      $
��Left=�6   $��15(�6K   ��62   �� $ To�6K   5      5      � 5   
   -   5        $��AttachmentPanel��5   !   $��2��6   5      (  "System.Windows.Controls.WebBrowser  5    
   -   5        $��WebBrowserContent��5    "   $��3��6   5!      5#      5$      