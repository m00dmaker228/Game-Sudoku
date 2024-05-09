using System.Windows.Forms;
using Classes;
using Classes.CoR;
using Classes.Factory;
using Classes.SudokuTypes;
using Classes.Visitor;
namespace MainWindow
{
    public partial class Playing : Form
    {
        //����� ����������� ��������

        Form choosingForm;

        int size;
        string difficulty;

        ISudokuFactory sudokuFactory;

        Sudoku sudoku;

        BaseHandler factory_one = new ReturnEasyFactory();
        BaseHandler factory_two = new ReturnNormalFactory();
        BaseHandler factory_three = new ReturnHardFactory();

        Button[,] buttons;

        SudokuService sudokuService = SudokuService.Instance;

        IVisitor visitor = new SudokuVisitor();
        public Playing(Form form, int size, string difficulty)
        {
            InitializeComponent();

            choosingForm = form;

            this.size = size;
            this.difficulty = difficulty;

            factory_two.SetNextHandler(factory_three);
            factory_one.SetNextHandler(factory_two);

            sudokuFactory = factory_one.HandleRequest(difficulty);

            //===================================������� ��̲��===================================
            switch (size)
            {
                case 4:
                    sudoku = sudokuFactory.CreateSmallSudoku();
                    break;
                case 9:
                    sudoku = sudokuFactory.CreateMediumSudoku();
                    break;
                case 16:
                    sudoku = sudokuFactory.CreateBigSudoku();
                    break;

                default:
                    break;
            }

            sudokuService.SetSudoku(sudoku);
            sudokuService.GenerateSudoku();

            buttons = new Button[size, size];
        }
        public Playing()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (sudokuService.ValidateSudoku())
            {
                MessageBox.Show("�� �������");
            }
            else
            {
                MessageBox.Show("�������");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void Playing_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (choosingForm != null)
            {
                bt_start.Enabled = true;
                choosingForm.Show();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bt_start.Enabled = false;
            sudoku.Accept(visitor);

            // ���������� �����, ��� ����������� ����������� ������� � ����
            int gridSize = size;
            if (gridSize != 4 && gridSize != 9 && gridSize != 16)
            {
                MessageBox.Show("������� ����� ������.");
                return;
            }

            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    Button button = new Button();
                    buttons[i, j] = button;
                    button.Size = new Size(50, 50);
                    button.Location = new Point(i * 50, j * 50);
                    int x = i; // �������� �������� "i" ��� ������������ � ��������� ����
                    int y = j; // �������� �������� "j" ��� ������������ � ��������� ����
                    
                    button.Text = sudokuService.GetSudokuNumber(x, y).ToString();

                    Font buttonFont = new Font("Modern No. 20", 14.25f);
                    button.Font = buttonFont;
                    
                    if (button.Text != "0")
                    {
                        button.Enabled = false;
                    }
                    else
                    {
                        button.BackColor = Color.White;
                    }

                    button.Click += (btnSender, btnEvent) =>
                    {
                        // ���� ������ ������ �� ����� �� 1 �� 9 � ����
                        int currentValue = int.Parse(((Button)btnSender).Text);
                        int newValue = (currentValue % 9) + 1;
                        ((Button)btnSender).Text = newValue.ToString();

                        sudokuService.setSudokuNumber(x, y, newValue);
                        // ��������� � MessageBox ��������� ������ �� ������ ��������
                        //MessageBox.Show($"������ [{x}, {y}] ������ �� {newValue}.");
                    };
                    this.Controls.Add(button);
                }
            }
        }
    }
}
