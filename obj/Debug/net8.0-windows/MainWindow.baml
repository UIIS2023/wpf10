   M S B A M L   `   `   `  ����H  DFudbalskiKlub, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:FudbalskiKlubFudbalskiKlub  5   	       FudbalskiKlub.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:FudbalskiKlub     5   	     � Title$  Fudbalski Klub��5   	   $	��450��6    $	��800��6-   .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5        $��dataGridCentralni��5
      $��Center=�6,   $��Center=�6I   $
��auto��6d   $
��auto��6r      
IsReadOnly$
 True��6      AlternatingRowBackground
 �2�2�   CanUserAddRows$ False��6�      SelectionUnit$ FullRow=�6�      SelectionMode$ Single=�6�   �� 5   
   $��Center=�6   $��30��62   $	��Top=�6?   $
��auto��6W    �� Orientation$ 
Horizontal=�6d   .+�5      �� -   5         ��Name$ btnKlub��5      $
��Klub��6&   $
��Left=�65   $��30��6P   $	��Top=�6\   $��75��6t   6   �� 5      -   5        $ btnIgrac��5      $��Igrac��6'   $
��Left=�67   $��30��6R   $	��Top=�6^   $��75��6v   6�   �� 5      -   5        $ 	btnTrener��5      $��Trener��6(   $
��Left=�69   $��30��6T   $	��Top=�6`   $��75��6x   6�   �� 5      -   5        $ btnUtakmica��5      $��Utakmica��6*   $
��Left=�6=   $��30��6X   $	��Top=�6d   $��75��6|   6�   �� 5      -   5        $ 
btnStadion��5      $��Stadion��6)   $
��Left=�6;   $��30��6V   $	��Top=�6b   $��75��6z   6�   �� 5      -   5        $ btnKarta��5      $��Karta��6'   $
��Left=�67   $��30��6R   $	��Top=�6^   $��75��6v   6�   �� 5      -   5        $ 	btnTurnir��5      $��Turnir��6(   $
��Left=�69   $��30��6T   $	��Top=�6`   $��75��6x   6�   �� 5      -	   5        $ btnClan��5      $
��Clan��6&   $
��Left=�65   $��30��6P   $	��Top=�6\   $��75��6t   6   5      �� 5   
   $��Center=�6   $��30��62   $��Bottom=�6?   $	��360��6Z   $ 
Horizontal=�6f   .+�5      �� -
   5        $ btnDodaj��5      $��Dodaj��6'   $	��120��67   6C   �� 5      -   5        $ 	btnIzmeni��5      $��Izmeni��6(   $	��120��69   6E   �� 5      -   5        $ 	btnObrisi��5      $��Obrisi��6(   $	��120��69   6E   5      5      5      