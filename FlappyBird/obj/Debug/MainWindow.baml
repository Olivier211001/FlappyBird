   M S B A M L   `   `   `  ����E  AFlappyBird, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:FlappyBird
FlappyBird  5   	   =#clr-namespace:FlappyBird.ViewModelsFlappyBird.ViewModels  5   	       FlappyBird.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:FlappyBird     5   	   3gmv#clr-namespace:FlappyBird.ViewModels     5   	     � Title$  
FlappyBird��5	   	   $	��450��6   $	��800��6)    � 	Resources 5
      *   $FlappyBird.ViewModels.GameViewModels   vm��%   &	          5   
   6   5      .��5      �� -   5        $��MyCanvas��5      |�. 
����ح�.+�5   
   �� -   5        $
��Play��5      $
��Play��6   $	��107��6h   
 �� Top$	 268��6t   $��30��6�    �� Left$ 10��6�   ��6,   �� *PlayCommand+ �� Source# [  6�   �� 5   
   $��images/clouds.png��6   $	��145��6+   $	��200��68   $ 73��6D   $ 59��6U   
 � Tag$ cloud��6e   6s   �� 5   
   $��images/clouds2.png��6   $	��145��6,   $	��200��69   $	 504��6E   $	 175��6W   $ cloud��6h   6v   �� 5   
   $��images/pipeBottom.png��6   $	��390��6/   $��66��6<   $
 obs1��6G   $	 288��6R   $	 151��6c   6w   �� 5   
   $��images/pipeTop.png��6   $	��390��6,   $��66��69   $
 obs1��6D   $
 -241��6O   $	 151��6a   6u   �� 5   
   $��images/pipeBottom.png��6   $	��390��6/   $��66��6<   $
 obs2��6G   $	 329��6R   $	 401��6c   6w   �� 5   
   $��images/pipeTop.png��6   $	��390��6,   $��66��69   $
 obs2��6D   $
 -186��6O   $	 401��6a   6u   �� 5   
   $��images/pipeBottom.png��6   $	��390��6/   $��66��6<   $
 obs3��6G   $	 288��6R   $	 679��6c   6w   �� 5   
   $��images/pipeTop.png��6   $	��390��6,   $��66��69   $
 obs3��6D   $
 -241��6O   $	 679��6a   6u   �� 5   
   -   5        $��
flappyBird��5   F   $��images/flappyBird.png��6   $��50��6/   $��36��6:   $
��Fill=�6X   $ 23��6g   $	 204��6x   6�   �� 5   
   -   5        $��txtScore��5      $��22(�6    $��	ExtraBold"�6.   $��	score : 0��6E   �� 5   
   -   5        $��txtTimer��5      $��22(�6    $��	ExtraBold"�6.   $��
Timer :  0��6E   $��61��6Z   $	��396��6f   $ 45��6r   6�   5      5      