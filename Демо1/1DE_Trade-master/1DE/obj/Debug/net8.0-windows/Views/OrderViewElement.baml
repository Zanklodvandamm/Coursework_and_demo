   M S B A M L   `   `   `  ����>  :1DE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:_1DE.Views
_1DE.Views  5      !    _1DE.Views.OrderViewElement   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:_1DE.Views     5      .��5	      � $	��730��6   .+�5
   
   �� ���	#FF498C51$��2q�6)   $��5q�6=     �� Padding$  1q�6H   ._�5      ��  �� Orientation$ Vertical=�6    � 	Resources 5       �� 
TargetType �� Triggers �� Binding �� Value �� Property �� Value��%  '��       �� 5      " ��6    5      �� 5       6*   �� *IsAllInStock+ True6K   .a�5   "   ��  � �� �	#7F20B2AA6?   5      �� 5       6*   �� *IsAllInStock+	 False6K   .a�5   "   ��  � �� �	#7FFF8C006?   5      5      5      .+�5      �� $ 
Horizontal=�6   ��66   Z� .+�5      �� $ Vertical=�6!   $��10q�68   ��6D   Z� .+�5      �� $ 
Horizontal=�6%   $��0,0,0,5q�6>   .+�5      �� $
��№ ��6(   	 J� Opacity$		 0.5Q�62   �� 5      $		 0.5Q�6A   ��6(   �� *	OrderId+6A   �� 5      $��Дата заказа: ��6(   $
��Bold"�6=   $��10,0,0,0q�6O   �� 5      ��6(   �� *	OrderDate+
 �� StringFormat$
 {0:dd.MM.yyyy}��5       �� 5"      $ 
Horizontal=�6%   $��0,0,0,5q�6>   .+�5#      �� $!��Дата доставки: ��6(   $
��Bold"�6?   $��0,0,0,0q�6Q   �� 5$      ��6(   �� *OrderDeliveryDate+$
 {0:dd.MM.yyyy}��5%      �� 5&      $��Клиент: ��6$   $
��Bold"�64   $��0,10,0,0q�6F   �� 5'      $ 
Horizontal=�6%   $��0,5,0,10q�6>   .+�5(      �� ��6(   �� *OrderUser.UserSurname+�� 5)      $�� ��6(   �� 5*      ��6(   �� *OrderUser.UserName+�� 5+      $�� ��6(   �� 5,      ��6(   �� *OrderUser.UserPatronymic+5-      5.      �� 50      $ Vertical=�6!   $��Center=�68   $��10,0,0,0q�6S   ��6e   Z� .+�52      �� $ ��Состав заказа:��6$   $��0,0,0,2q�6:   �� 53      ��6'   �� *Orderproducts+��54      �� 55   "   .R�56   &   �� $ Vertical=�61   .+�57   *   �� $ 
Horizontal=�65   .+�58   .   �� $
��Wrap=�6t   $
��Bold"�6�   ��68   �� *,*ProductArticleNumberNavigation.ProductName+6�   �� 59   .   $��| Кол-во: ��68   $��10,0,0,0q�6J   �� 5:   .   ��68   �� *ProductQuantity+�� 5;   .   $�� | Цена: ��68   $��10,0,0,0q�6I   �� 5<   .   ��68   �� *,*ProductArticleNumberNavigation.ProductCost+$
 	{0:N2} Р���� 5=   .   $�� | Скидка: ��68   $��10,0,0,0q�6K   �� 5>   .   ��68   �� *75ProductArticleNumberNavigation.ProductCurrentDiscount+$

 {0}%��5?   +   5@   '   5A   #   5C      5E      5F      �� 5G      $ 
Horizontal=�6   $��Center=�66   $��0,2,0,02q�6S   ��6e   Z� .+�5H      �� $��Общая сумма: ��6    $
��Bold"�65   �� 5I      ��6    �� *TotalOrderSum+$
 {0:N2} Руб���� 5J      $/��) | Общий размер скидки: ��6    $
��Bold"�6@   $��10,0,0,0q�6R   �� 5K      ��6    �� *TotalOrderDiscount+$

 {0}%��5L      5M      5O      5P      5Q      