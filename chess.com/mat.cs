using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess.com
{
    class mat
    {
        public static bool chahwhite = true;
        public static bool matforwhite()
        {
            //значит принимаем доску после хода и проверяем есть ли мат белым
            // проверяем возможность хода на каждую клетку для каждой фигуры
            // проверяем есть ли шах после этого хода
            //если шах при любом ходе значит на доске мат
            // хотя зачем нам вообще принимать массив у нас же есть статический массив скопируем его и будем проверять

            //находим координаты черного короля
            int xkor = 0;
            int ykor = 0;
            string namefigure;
            int white = 0;
            //вычисляем количество белых фигур
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    string name = figuresarr.figures[x, y];
                    if (name != null)
                    {
                        if (name[0] == 'б')
                        {
                            white += 1;
                        }
                    }
                }
            }
            for (int i = 0; i < 8; i++)
            {
                if (chahwhite == false) { break; }
                for (int j = 0; j < 8; j++)
                {//первые два фора для перебора фигур
                    namefigure = figuresarr.figures[i, j];
                    
                    for (int i1 = 0; i1 < 8; i1++)//по идее эти два фора для перебора полей для хода
                    {// надо будет выйти из этого цикла если не будет шаха при каком либо ходе этой фигуры будет не шах да и можно будет вообще из цикла выйти и вывести мат фалзе
                        
                        for (int j1 = 0; j1 < 8; j1++)
                        {
                            //
                            //
                            string[,] mat = new string[8, 8];
                            for (int imat = 0; imat < 8; imat++)// это короче копирую массив 
                            {
                                for (int jmat = 0; jmat < 8; jmat++)
                                {
                                    mat[i, j] = figuresarr.figures[imat, jmat];
                                }
                            }
                            //
                            //
                            bool mogno = false;
                            //i1 j1 координаты куда я хочу переместить фигуру i j это координаты фигуры
                            mogno = chahforwhite(i1, j1, namefigure, i, j, mat);// и если ход возможен значит мы перемещаем фигуру и проверяем шах
                            string text = i1+" " + j1+" "+  namefigure + i + j;
                            if (mogno) { MainWindow.chek(text); }
                            if (mogno)
                            {
                                if (namefigure != null)
                                {
                                    if (namefigure[0] == 'б')
                                    {
                                        mat[i1, j1] = namefigure;
                                        mat[i, j] = null;
                                        //поиск белого короля на доске
                                        for (int x = 0; x < 8; x++)
                                        {
                                            for (int y = 0; y < 8; y++)
                                            {
                                                if (mat[x, y] == "бкороль")
                                                {
                                                    xkor = x;
                                                    ykor = y;
                                                }
                                            }
                                        }

                                        //проверка на шах при данном положении фигур далее и если шах то 
                                        if (namefigure != null)
                                        {
                                            if (namefigure[0] == 'б')
                                            {
                                                chahwhite = chah(xkor, ykor, mat);
                                                break;
                                            }
                                        }
                                        else { chahwhite = true; }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return chahwhite;
        }

        // chaforwhite изменять не надо он проверяет возможен ли такой ход и теперь нам надо чтобы в проверке шаха проверялось бьет ли какая либо фигура по белому королю
        public static bool chahforwhite(int xforchahcorol, int yforchahcorol, string nameofigureinmassdo, int xofigureinmassdo, int yofigureinmassdo, string[,] massdo)
        {
            bool mogno = false;
            string namevybor = nameofigureinmassdo;
            switch (namevybor)
            {
                case "бферзь":
                    mogno = bferz2.Bferzrule(xforchahcorol, yforchahcorol, nameofigureinmassdo, xofigureinmassdo, yofigureinmassdo, massdo);
                    break;
                case "бпешка":
                    mogno = bpeshka2.bpeshkarule(xforchahcorol, yforchahcorol, nameofigureinmassdo, xofigureinmassdo, yofigureinmassdo, massdo);//тут короче проверка на то дошла ли пешка до конца
                    break;
                case "бпешка2":
                    mogno = bpeshka2.bpeshkarule2(xforchahcorol, yforchahcorol, nameofigureinmassdo, xofigureinmassdo, yofigureinmassdo, massdo);
                    break;
                case "бладья":
                    mogno = blad2.Bferzrule(xforchahcorol, yforchahcorol, nameofigureinmassdo, xofigureinmassdo, yofigureinmassdo, massdo);
                    break;
                case "бслон":
                    mogno = bslon2.Bferzrule(xforchahcorol, yforchahcorol, nameofigureinmassdo, xofigureinmassdo, yofigureinmassdo, massdo);
                    break;
                case "бконь":
                    mogno = bkon2.Bferzrule(xforchahcorol, yforchahcorol, nameofigureinmassdo, xofigureinmassdo, yofigureinmassdo, massdo);
                    break;
                case "бкороль":
                    mogno = bkorol2.Bferzrule(xforchahcorol, yforchahcorol, nameofigureinmassdo, xofigureinmassdo, yofigureinmassdo, massdo);
                    break;
            }
            return mogno;
        }
        // теперь шах будет принимать только массив с расположением фигур дальше он будет циклом фор проходить по всем фигурам  и проверять бьет ли какая нибудь по белому королю
        //
        public static bool chah(int xforchahcorol, int yforchahcorol, string[,] massdo)
        {
            string namevybor = "";
            bool mogno = false;
            for (int x = 0; x < 8; x++)
            {
                if (mogno) { break; }
                for (int y = 0; y < 8; y++)
                {
                    int xofigureinmassdo = x;
                    int yofigureinmassdo = y;
                    namevybor = massdo[x, yforchahcorol];
                    string nameofigureinmassdo = "";
                    switch (namevybor)
                    {
                        case "чферзь":
                            mogno = chferz2.Bferzrule(xforchahcorol, yforchahcorol, nameofigureinmassdo, xofigureinmassdo, yofigureinmassdo, massdo);
                            break;
                        case "чпешка":
                            mogno = chpeshka2.bpeshkarule(xforchahcorol, yforchahcorol, nameofigureinmassdo, xofigureinmassdo, yofigureinmassdo, massdo);//тут короче проверка на то дошла ли пешка до конца
                            break;
                        case "чпешка2":
                            mogno = chpeshka2.bpeshkarule2(xforchahcorol, yforchahcorol, nameofigureinmassdo, xofigureinmassdo, yofigureinmassdo, massdo);
                            break;
                        case "чладья":
                            mogno = chlad2.Bferzrule(xforchahcorol, yforchahcorol, nameofigureinmassdo, xofigureinmassdo, yofigureinmassdo, massdo);
                            break;
                        case "чслон":
                            mogno = chslon2.Bferzrule(xforchahcorol, yforchahcorol, nameofigureinmassdo, xofigureinmassdo, yofigureinmassdo, massdo);
                            break;
                        case "чконь":
                            mogno = chkon2.Bferzrule(xforchahcorol, yforchahcorol, nameofigureinmassdo, xofigureinmassdo, yofigureinmassdo, massdo);
                            break;
                        case "чкороль":
                            mogno = chkorol2.Bferzrule(xforchahcorol, yforchahcorol, nameofigureinmassdo, xofigureinmassdo, yofigureinmassdo, massdo);
                            break;

                    }
                }
            }
            return mogno;
        }
    }
}
