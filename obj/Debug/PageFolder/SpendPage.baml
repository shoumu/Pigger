   M S B A M L   `   `   `  ����|  xSystem.Windows.Controls.DataVisualization.Toolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35�{clr-namespace:System.Windows.Controls.DataVisualization.Charting;assembly=System.Windows.Controls.DataVisualization.Toolkit2System.Windows.Controls.DataVisualization.Charting  5      
 Pigger!   Pigger.PageFolder.SpendPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      �chart{clr-namespace:System.Windows.Controls.DataVisualization.Charting;assembly=System.Windows.Controls.DataVisualization.Toolkit     5        N� Title$  	SpendPage��5      .��5      � .+�5   
   >   8System.Windows.Controls.DataVisualization.Charting.Chart  $��0,45,0,0q�6      Series 5      E   ?System.Windows.Controls.DataVisualization.Charting.ColumnSeries  -   5        $��spend��5   %   ?   9System.Windows.Controls.DataVisualization.Charting.Series   Title$ 支出��6J   H   BSystem.Windows.Controls.DataVisualization.Charting.DataPointSeries   ItemsSource 62   ��    DependentValueBinding 5   %   �� *Value+   IndependentValueBinding 5   %   �� *Key+5      �� 5   
   $��年份��6   $
��Left=�6   $��	10,10,0,0q�68   $	��Top=�6K   �� 5   
   -   5        $
��year��5      $
��Left=�6   $��	49,10,0,0q�6:   $	��Top=�6M   $	��120��6e   �� 5   
   $��月份��6   $
��Left=�6   $��
185,10,0,0q�68   $	��Top=�6L   �� 5   
   -   5        $��month��5      $
��Left=�6    $��
224,10,0,0q�6;   $	��Top=�6O   $	��120��6g   �� 5   
   -   5        $��ok��5      $��查看��6   $
��Left=�6(   $��
394,10,0,0q�6C   $	��Top=�6W   $��75��6o   $��25��6z   6�   5      5      