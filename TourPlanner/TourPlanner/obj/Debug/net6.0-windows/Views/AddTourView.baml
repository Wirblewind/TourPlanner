   M S B A M L   `   `   `  ����F  BTourPlanner, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:TourPlanner.ViewsTourPlanner.Views  5   	   #    TourPlanner.Views.AddTourView   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:TourPlanner.Views     5   	   Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  5   	     � Title$  AddTourView��5	   	   $	��450��6   $	��800��6*    � 
ResizeMode$ NoResize=�5
   	   .��5      � .+�5   
   �� $��Center=�6   $��Center=�62   .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��Name:��6   $	��200��6(   $��Center=�64   �� 5      -   5        $��NameTextBox��5   4   $	��500��6G   $��20q�6S   $��Center=�6_   ��6   �� *
Tourname+6_   5      �� 5      $ 
Horizontal=�6   .+�5      �� $��Tour Description:��6   $	��200��64   $��Center=�6@   �� 5      -   5        $��TourDescriptionTextBox��5   ;   $	��500��6Y   $��20q�6e   $��Center=�6q   $��72��6�   ��6   �� *Tourdescription+6�   5      �� 5      $ 
Horizontal=�6   .+�5      �� $��From:��6   $	��200��6(   $��Center=�64   �� 5      -   5        $��FromTextBox��5   4   $	��500��6G   $��20q�6S   $��Center=�6_   ��6   �� *
Tourfrom+6_   5      �� 5      $ 
Horizontal=�6   .+�5      �� $	��To:��6   $	��200��6&   $��Center=�62   �� 5      -   5        $��	ToTextBox��5   2   $	��500��6C   $��20q�6O   $��Center=�6[   ��6   �� *Tourto+6[   5      �� 5      $ 
Horizontal=�6   .+�5      �� $��Transport Type:��6   $	��200��62   $��Center=�6>   �� 5       -   5        $��TransportTypeComboBox��5    F   $	��500��6c   $��20q�6o   $��Center=�6{    �� SelectedItem 6   �� *Tourtransporttype+.@�5!      �� $��fastest��6#   �� 5"      $��shortest��6#   �� 5#      $��
pedestrian��6#   �� 5$      $��bicycle��6#   5%      5&      �� 5'      $ 
Horizontal=�6   $��Center=�62   $��20q�6O   .+�5(      �� -   5        $��
BackButton��5(   (   $
��Back��6   $	��200��6:   $��20q�6F   �� 5)      -   5        $��	AddButton��5)   '   $	��Add��6   $	��200��68   $��20q�6D   6P   5*      5+      � 5,   
   
������� J� Opacity$	 0.5Q�6!   y�6/   �� *LoadingBackGroundVisibility+5-      "  FontAwesome.WPF.ImageAwesome  5.   
      Icon$ CircleOutlineNotch=�6      Spin$
 True��64   $��48��6@   $��48��6L      
Foreground
 �OO/�y�6r   �� *LoadingForeGroundVisibility+5/      50      