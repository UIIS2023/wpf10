   M S B A M L   `   `   `  ����H  DFudbalskiKlub, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:FudbalskiKlub.FormeFudbalskiKlub.Forme  5   	   "    FudbalskiKlub.Forme.FrmKarta   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:FudbalskiKlub.Forme     5   	     � Title$  Dodaj / Izmeni Kartu��5   	   $	��230��6&   $	��300��63   .��5	      � .+�5
   
   �� $��Sediste:��6   $
��Left=�6#   $��	40,30,0,0q�6>   $	��Top=�6Q   �� 5   
   $��	Pozicija:��6   $
��Left=�6$   $��	40,60,0,0q�6?   $	��Top=�6R   �� 5   
   $��	Utakmica:��6   $
��Left=�6$   $��	40,90,0,0q�6?   $	��Top=�6R   �� 5   
   -   5         ��Name$ 
txtSediste��5      $
��Left=�6&   $��
150,35,0,0q�6A    �� TextWrapping$
 Wrap=�6U   $�� ��6i   $	��Top=�6q   $	��120��6�   �� 5   
   -   5        $ txtPozicija��5      $
��Left=�6'   $��
150,65,0,0q�6B   $
 Wrap=�6V   $�� ��6j   $	��Top=�6r   $	��120��6�   �� 5   
   -   5         ��Name$ 
cbUtakmica��5      $
��Left=�6'   $��
150,95,0,0q�6B   $	��Top=�6V   $	��120��6n    �� DisplayMemberPath$ 	Protivnik��6z    �� SelectedValuePath$ 
UtakmicaID��6�   �� 5   
   -   5         ��Name$ 
btnSacuvaj��5      $��Sacuvaj��6%   $
��Left=�67   $��
60,150,0,0q�6R   $	��Top=�6f   6~   �� 5   
   -   5        $ 	btnOtkazi��5      $��Otkazi��6$   $
��Left=�65   $��200,150,0,0q�6P   $	��Top=�6e   6}   5      5      