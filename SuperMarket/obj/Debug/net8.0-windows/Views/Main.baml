   M S B A M L   `   `   `  ����F  BSuperMarket, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:SuperMarket.ViewsSuperMarket.Views  5   	   =#clr-namespace:SuperMarket.ViewModelSuperMarket.ViewModel  5   	       SuperMarket.Views.Main   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:SuperMarket.Views     5   	   2vm#clr-namespace:SuperMarket.ViewModel     5   	     � Title$
  Main��5	   	   $	��450��6   $	��800��6#   
�������.��5      ]� $��False��6   .+�5   
   o� $	��Top=�6   ��5      �� 5       �� EndPoint$ 0,0.1&�6&    �� 
StartPoint$	 0,0&�67   .��5      �  � Color$ 	#FF3A60AD��6#    � Offset$ 0.528Q�65   � 5      $ 	#FF6A85D8��6#   $
 0.01Q�65   5      .@�5      m� -   5        $��Users��5   &   $��Users��6    m� CommandParameter$ 3��6Y   $��15(�6n   $��Center=�6|   
��� ��� m� Command 63   �� *OpenWindowCommand+6�   m� 5      -   5        $��Bonuri��5   '   $��Bonuri��6   $ 4��6[   $��15(�6p   $��Center=�6~   
��� ��� 65   �� *OpenWindowCommand+6�   m� 5      -   5        $��
Producator��5   +   $��
Producator��6   $ 5��6c   $��15(�6x   $��Center=�6�   
��� ��� 6=   �� *OpenWindowCommand+6�   m� 5      -   5        $��Produse��5   (   $��Produse��6   $ 6��6]   $��15(�6r   $��Center=�6�   
��� ��� 67   �� *OpenWindowCommand+6�   m� 5      -   5        $
��Stoc��5   (   $��Stocuri��6   $ 7��6Z   $��15(�6o   $��Center=�6}   
��� ��� 64   �� *OpenWindowCommand+6�   m� 5      -   5        $��FilterProducator��5   +   $��
FilterProd��6   $ 8��6i   $��15(�6~   $��Center=�6�   
��� ��� 6C   �� *OpenWindowCommand+6�   �� 5      $��Right=�6   $
��50,0q�64   �� 5      -   5         ��Name$
 Cont��5      $��15(�6;   
��� �����6"   �� *name+6_   �� 5      -   5        $
 Role��5      $��15(�6;   
��� ���$��-10,0q�6]   ��6"   �� *role+6n   5      5      5      