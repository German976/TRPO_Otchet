   M S B A M L   `   `   `  ����?  ;Wpf1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:Wpf1Wpf1  5   	       Wpf1.Basket   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:Wpf1     5   	     � Title$  Basket��5   	   $	��450��6   $	��800��6%   .��5
      �  � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $��* �6   �� 5      $��30 �6   .+�5   
   � $��0��6   
���   � � ColumnDefinitions 5      �� 5      $��50 �6#   �� 5      $��2* �6#   �� 5      $��* �6#   .+�5      �� $��0��6   �� 5      $��1��6   $��Basket��6(      
TitleStyle#��[  5      $
��Left=�6<   $��
294,12,0,0q�6W   $	��Top=�6k   �� 5      -   5        $��buttonExitBasket��5      $��2��6-   $
��Menu��6=   $��
128,9,10,9q�5      
�������$��	Bodoni MT)�5      $��14(�6,   ��5   <   Z� 5      �� 5      -   5        $��
labelSumma��5      $��1��6'   
�������$�� ��6`   $
��Left=�6k   $��29,0,0,0q�6�   $��Center=�6�    J� RenderTransformOrigin$ 0.117,0.186&�6�   ��67   Z� 6�   5       � 5!   
   $��1��6    5"      �� 5#      $��4* �6    �� 5$      $��* �6    .+�5&      &   System.Windows.Controls.DataGrid  -   5          Name$ Basket_Menu��5&      
�������$��0q�6?      AutoGenerateColumns .  
������    
IsReadOnly .   DataGrid#��[ 6�      Columns 5'      0  *System.Windows.Controls.DataGridTextColumn  5(      ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��6)   	   Width5  /System.Windows.Controls.DataGridLengthConverter$
	 2.5* 6P   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 67   �� *Name+6P     5)      $ Price��6)   $	 * 6R   
 68   �� *Price+6R     5*      $ Amount��6)   $	 * 6T   
 69   �� *Amount+6T     5+      $ Result��6)   $	 * 6S   
 69   �� *Total+6S   4  .System.Windows.Controls.DataGridTemplateColumn  5,      $	 Use��6-   $	 * 6:      CellTemplate 5-      �� 5.      .R�5/   "   ��  �� Orientation$ 
Horizontal=�6-   .+�50   &   ��  ��Name$ btnIncr��6-   -   5        $��+��50   >   
������ $��25��6c   6n   �� 51   &   $ btnDecr��6-   -   5        $��-��51   >   
������ $��25��6c   6n   �� 52   &   $ btnDel��6-   -   5        $��x��52   =   
������ $��25��6b   6m   53   #   54      56      58      �� 59      -   5        $ Create_order_basket��59      $��Create order��6T   $��	Bodoni MT)�6k   $��14(�6�   
�������
������ $
��Left=�6�   $��	702,0,0,0q�6�   $��1��6�   $��Center=�6�   $��79��6  $��33��6  �� 5:      $��Summa order��6   
�������$��	Bodoni MT)�6=   $��14(�6T   $
��Left=�6b   $��	478,5,0,0q�6}   $��1��6�   $	��Top=�6�   �� 5;      -   5         ��Name$ summa_order_basket��5;      
�������$��	Bodoni MT)�6G   $��14(�6^   $
��Left=�6l   $��
613,10,0,0q�6�   $��1��6�   $
��Wrap=�6�   $��0��6�   $	��Top=�6�   �� 5<      $��Summa account��6   $��	Bodoni MT)�6,   $��14(�6C   
�������$
��Left=�6d   $��
478,34,0,0q�6   $��1��6�   $	��Top=�6�   �� 5=      -	   5        $ summa_account_basket��5=      $
��Left=�66   $��
613,39,0,0q�6Q   $��1��6f   $
��Wrap=�6s   $��	Bodoni MT)�6�   $��14(�6�   
�������$��0��6�   $	��Top=�6�   ��5>      �� 5?       �� ImageSource$ /Resurses/Basket.jpg��6    j� Stretch$ UniformToFill=�6@   6Z   5A      � 5C   
   $��2��6   
���   � 5D      �� 5E      $��* �6#   �� 5F      $��* �6#   .+�5H      �� $��0��6   $��Voitovich German��6(   $��Center=�5I      $��Center=�65   $��	Bodoni MT)�5J      
�������$��20(�6B   �� 5K      $��1��6   $��xxxxxx@gmail.com��6(   $��Center=�5L      
�������$��Center=�6K   $��	Bodoni MT)�5M      $��20(�6/   5N      5O      5P      