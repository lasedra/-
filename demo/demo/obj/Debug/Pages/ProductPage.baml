   M S B A M L   `   `   `  ����?  ;demo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:demo.Pages
demo.Pages  5      clr-namespace:demodemo  5          demo.Pages.ProductPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:demo.Pages     5      %parentclr-namespace:demo     5      -   5          N� Title$  ProductPage��5
      .��5      �  � RowDefinitions 5   
   �� 5      $��60 �6   �� 5      $��* �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $	��top=�6.   $��0��6F   .+�5      �� $��10q�6   $��Center=�6%   $ 
Horizontal=�6@   .+�5      �� -   5        $��FactItemsTextBlock��5      $��16(�66   $
��Bold"�6D   �� 5      $�� из ��6   $��16(�6(   $
��Bold"�66   �� 5      -   5        $��AllItemsTextBlock��5      $��16(�65   $
��Bold"�6C   5      �� 5      $��
Найти��6   $��10q�6%   $��16(�61   $��Medium"�6?   $��Center=�6S   �� 5      -   5        $��SearchTextBox��5   P   $	��150��6   $��Center=�6"   $��30��6D   6e   �� 5      $ ��Производитель��6   $��10q�6-   $��16(�69   $��Medium"�6G   $��Center=�6[   �� 5      -   5        $��ManufComboBox��5      $	��200��6,   $��30��68   $��10q�6D    �� DisplayMemberPath$
 Name��5       �� SelectedIndex$ 0��5      �� 5      $��Center=�6   .+�5      	� -   5        $��CheapRadioBttn��5      $#��Сначала дешевле��64   6N   	� 5      -   5        $��PriceyRadioBttn��5      $!��Сначала дороже��65   6N   5       �� 5!      -   5        $��DropFilters��5!      $%��Сбросить фильтры��6B   $��250 10 0 10q�6]   
����  �
�������$
��Bold"�6�   5"      ]� 5$   
   $
��auto��6   $
��auto��6"   $��1��6/   .+�5%      �� -	   5         ��Name$ ListViewProducts��5%      $��1��61    � ContextMenu 5&      �� 5'      .@�5(      m� -
   5        $��
AddProduct��5(   5   $��Добавить��6#   6G   m� 5)      -   5        $��EditProduct��5)   5   $��Изменить��6#   6H   m� 5*      -   5        $��DeleteProduct��5*   4   $��Удалить��6#   6I   5+      ��5-      �� 5.       �� 
TargetType" ��6    �� Triggers 5/      �� 51      	 �� Binding	 6*   �� *
IsActive+
 �� Value
 True6G   .a�52   "   ��  �� Property �@J�Opacity �� Value$ 1Q�6=   53      �� 54      	 6*   �� *
IsActive+	
 False6G   .a�55   "   ��  �@J�Opacity$	 0.2Q�6=   56      .�58      ��  � ��
 ���� 67   59      ��5;      �� 5<      .R�5=      �  � Orientation$ 
Horizontal=�6$   $	��Top=�6=   $
��2000��6U   5>      ��5@      �� 5A      .R�5B      �� $��ProductBorder��6U   $��10q�6!   $	��230��6-    � Cursor$
 Hand��69   $
��auto��6G   ._�5C      �� $��Center=�6)   $��Center=�6F   .+�5D   "   �� $	��100��6)   $	��110��65    �� CornerRadius$ 5��6B   $��5q�6S    J� Effect 5E   &   3  -System.Windows.Media.Effects.DropShadowEffect  5F   *      ShadowDepth$ 1Q�6;   ._�5H   &   ��  ��Name$ PhotoProduct��6,   ��6B   �� *PhotoProduct+5I   #   �� 5J   "   $��5q�6,    �� TextAlignment$ Center=�6{   $��17(�6�   $��Franklin Gothic Medium)�6�   ��67   �� *Cost+ �� StringFormat$ c�� �� ConverterCulture$ ru_Ru��6�   �� 5K   "   $	��5 0q�6,   $��15(�6P   $	��220��6^   $ Center=�6j   $
��Wrap=�6�   ��69   �� *Title+6�   5L      5M      5N      5P      �� 5Q      -   5        $��
EmptyPanel��5Q   6   $��Center=�6   $��Center=�6I   $��1��6d   .+�5R      �� $&�� Ничего не найдено��6   $��40(�65   $
��Bold"�6C   5S      5T      5U      5V      