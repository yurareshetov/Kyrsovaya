   M S B A M L   `   `   `  ����B  >Yuro4ka, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:Yuro4kaYuro4ka  5   	       Yuro4ka.OrderWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Yuro4ka     5   	   $	��450��5	   
   $	��800��6     � Title  5   	   �� *
WindowName+.��5
      �  � ColumnDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6    .+�5   
   �� $��1��6    �� Orientation$ 
Horizontal=�6%   y�6>   �� *
NewProduct+.+�5      �� $/��)Идентификатор услуги: ��6   �� 5      ��6   �� *CurrentService.Id+5      �� 5   
   $��1��6   $
��5 60q�6%   .+�5      �� $��ВНомер��6   �� 5      ��6   �� *CurrentService.Number+�� 5      $��Время заказа��6   �� 5      ��6   �� *CurrentService.Date+�� 5      $��Цена��6   �� 5      ��6   �� *CurrentService.Total+�� 5      $��Курьер��6   �� 5      ��6   �� *CurrentService.Delivery+�� 5#      -   5         ��Name$ 
SaveButton��5#   ,   $	��100��6   $��5q�6!   $
��Left=�6Y   .��6t   Сохранить6   5$      5%      5&      