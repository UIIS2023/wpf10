   M S B A M L   `   `   `  ����H  DFudbalskiKlub, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:FudbalskiKlub.FormeFudbalskiKlub.Forme  5   	   $    FudbalskiKlub.Forme.FrmStadion   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:FudbalskiKlub.Forme     5   	     � Title$  Dodaj / Izmeni Stadion��5   	   $	��230��6(   $	��300��65   .��5	      � .+�5
   
   �� $��Klub:��6   $
��Left=�6    $��	40,30,0,0q�6;   $	��Top=�6N   �� 5   
   $��	Utakmica:��6   $
��Left=�6$   $��	40,60,0,0q�6?   $	��Top=�6R   �� 5   
   $��Informacije:��6   $
��Left=�6'   $��	40,90,0,0q�6B   $	��Top=�6U   �� 5   
   -   5         ��Name$ txtInformacije��5      $
��Left=�6*   $��
150,95,0,0q�6E    �� TextWrapping$
 Wrap=�6Y   $�� ��6m   $	��Top=�6u   $	��120��6�   �� 5   
   -   5         ��Name$ cbKlub��5      $
��Left=�6#   $��
150,35,0,0q�6>   $	��Top=�6R   $	��120��6j    �� DisplayMemberPath$ Naziv��6v    �� SelectedValuePath$ KlubID��6�   �� 5   
   -   5        $ 
cbUtakmica��5      $
��Left=�6'   $��
150,65,0,0q�6B   $	��Top=�6V   $	��120��6n   $ 	Protivnik��6z   $ 
UtakmicaID��6�   �� 5   
   -   5         ��Name$ 
btnSacuvaj��5      $��Sacuvaj��6%   $
��Left=�67   $��
60,150,0,0q�6R   $	��Top=�6f   6~   �� 5   
   -   5        $ 	btnOtkazi��5      $��Otkazi��6$   $
��Left=�65   $��200,150,0,0q�6P   $	��Top=�6e   6}   5      5      