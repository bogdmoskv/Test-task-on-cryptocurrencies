   M S B A M L   `   `   `  ����R  NCryptocurrenciesProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:CryptocurrenciesProject.ViewsCryptocurrenciesProject.Views  5   	   W0clr-namespace:CryptocurrenciesProject.ViewModels"CryptocurrenciesProject.ViewModels  5   	   6    0CryptocurrenciesProject.Views.CryptoCurrencyView   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   =local+clr-namespace:CryptocurrenciesProject.Views     5   	   Clocal10clr-namespace:CryptocurrenciesProject.ViewModels     5   	   X TFontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fFfa=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  5   
   $	��700��5
   	   $	��640��6     � WindowStartupLocation$  CenterScreen=�6"    � 
ResizeMode$ NoResize=�5   	    � Icon$1 +/Views/AxialisIconWorkshopClassic_11714.png��6    � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $+ %/Styles/CryptoCurrencyViewStyles.xaml?�6%   %    5      .��5      �    WindowStyle#��[  6    � ColumnDefinitions 5   
   �� 5      $��1* �6   .+�5   
   � $��0��6    � RowDefinitions 5       �� 5!      $
��Auto �6    �� 5"      $
��Auto �6    �� 5#      $
��Auto �6    �� 5$      $
��Auto �6    �� 5%      $
��Auto �6    �� 5&      $
��Auto �6    �� 5'      $
��Auto �6    �� 5(      $
��Auto �6    �� 5)      $
��Auto �6    .+�5+      � $��0��6    5,      �� 5-      $
��Auto �6$   �� 5.      $
��Auto �6$   �� 5/      $
��Auto �6$   �� 50      $
��Auto �6$   �� 51      $
��Auto �6$   �� 52      $
��Auto �6$   �� 53      $
��Auto �6$   �� 54      $
��Auto �6$   �� 55      $
��Auto �6$   �� 56      $
��Auto �6$   �� 57      $
��Auto �6$   .+�5:      � $��0��6    5;      �� 5<      �� 5=      .+�5@      �� $��0��6    $*��$Назва криптовалюти:��60   $��18(�6K   $
��Bold"�6Y   $��10q�6k   $��Center=�6w   �� 5A      $��1��6   $��0��6S   $��18(�6a   $��10q�6o   $��Center=�6{    �� 
IsReadOnly$
 True��6�   ��6.   �� *SelectedCrypto.Name+6�   5C      � 5G      $��1��6    5H      �� 5I      �� 5J      .+�5M      �� $��Символ:��6    $��18(�6/   $
��Bold"�6=   $��10q�6O   $��Center=�6\   �� 5N      $��1��6F   $��18(�6V   $��10q�6d   $��Center=�6p   $
 True��6�   ��6   �� *SelectedCrypto.Symbol+6�   5O      � 5Q      $��2��6    5R      �� 5S      �� 5T      .+�5W      �� $��	Ранг:��6    $��18(�6-   $
��Bold"�6;   $��10q�6M   $��Center=�6Z   �� 5X      $��1��6D   $��18(�6T   $��10q�6b   $��Center=�6n   $
 True��6�   ��6   �� *SelectedCrypto.Rank+6�   5Y      � 5\      $��3��6    5]      �� 5^      �� 5_      .+�5b      �� $��Ціна (USD):��6    $��18(�63   $
��Bold"�6A   $��10q�6S   $��Center=�6`   �� 5c      $��1��6_   $��18(�6o   $��10q�6}   $��Center=�6�   $
 True��6�   ��6   �� *SelectedCrypto.PriceUsd+	 �� StringFormat$	 {0:C2}��6�   5d      � 5g      $��4��6    5h      �� 5i      �� 5j      .+�5m      �� $^��XПоточна кількість одиниць
криптовалюти в обігу:��6    $��18(�6\   $
��Bold"�6j   $��10q�6|   $��Center=�6�   �� 5n      $��1��6F   $��18(�6V   $��10q�6d   $��Center=�6p   $
 True��6�   ��6   �� *SelectedCrypto.Supply+6�   5o      � 5r      $��5��6    5s      �� 5t      �� 5u      .+�5x      �� $����Максимальна кількість одиниць 
криптовалюти, яка може 
існувати в обігу��6    $��18(�6y   $
��Bold"�6�   $��10q�6�   $��Center=�6�   �� 5y      $��1��6I   $��18(�6Y   $��10q�6g   $��Center=�6s   $
 True��6�   ��6   �� *SelectedCrypto.MaxSupply+6�   5{      � 5      $��6��6    5�      �� 5�      �� 5�      .+�5�      �� $6��0Ринкова капіталізація (USD):��6    $��18(�6D   $
��Bold"�6R   $��10q�6d   $��Center=�6q   �� 5�      $��1��6c   $��18(�6s   $��10q�6�   $��Center=�6�   $
 True��6�   ��6   �� *SelectedCrypto.MarketCapUsd+$	 {0:C2}��6�   5�      � 5�      $��7��6    5�      �� 5�      �� 5�      .+�5�      �� $N��HОб'єм торгів криптовалютою 
за 24 год (USD):��6    $��18(�6Y   $
��Bold"�6g   $��10q�6y   $��Center=�6�   �� 5�      $��1��6d   $��18(�6t   $��10q�6�   $��Center=�6�   $
 True��6�   ��6   �� *SelectedCrypto.VolumeUsd24Hr+$	 {0:C2}��6�   5�      � 5�      $��8��6    5�      �� 5�      �� 5�      .+�5�      �� $b��\Відсоток зміни ціни
криптовалюти за останні 24 год:��6    $��18(�6`   $
��Bold"�6n   $��10q�6�   $��Center=�6�   �� 5�      $��1��6h   $��18(�6x   $��10q�6�   $��Center=�6�   $
 True��6�   ��6   �� *" SelectedCrypto.ChangePercent24Hr+$	 {0:C2}��6�   5�      � 5�      $��9��6    5�      �� 5�      �� 5�      .+�5�      �� $e��_Середньозважена ціна
криптовалюти за останні 24 год:��6    $��18(�6a   $
��Bold"�6o   $��10q�6�   $��Center=�6�   �� 5�      $��1��6_   $��18(�6o   $��10q�6}   $��Center=�6�   $
 True��6�   ��6   �� *SelectedCrypto.Vwap24Hr+$	 {0:C2}��6�   5�      �� 5�      $��	0,15,0,15q�6   $��10��6-     	addButton#��[ 6;   ��6^   �� *RefreshCommand+.��5�      �� 
 �� Orientation$
 
Horizontal=�6!   .+�5�      !  FontAwesome.Sharp.IconImage  �  �FontAwesome.Sharp.IconImageBase`1[[FontAwesome.Sharp.IconChar, FontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10f]]   Icon$ Refresh=�6(   $��Center=�67   $��11��6R   $��11��6]   $��0 1 8 0q�6i      
Foreground 5�      �� 5�   "    �� Color$ White��62   5�      �� 5�      $)��#Оновити інформацію��6$   5�      5�      5�      5�      5�      5�      