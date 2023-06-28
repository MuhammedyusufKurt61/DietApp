using DietApp.BLL.Abstract;
using DietApp.Entity;
using DietApp.Systm;
using DietApp.ViewModels.CategoryViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DietApp.WinUI.AdminScreen.CategoryScreen
{
    public partial class CategoryForm : Form
    {
        private readonly ICategoryBLL _categoryBLL;
        public CategoryForm(ICategoryBLL categoryBLL)
        {
            InitializeComponent();
            _categoryBLL = categoryBLL;
        }

        private void CategoryForm_Load(object sender, EventArgs e)
        {
            Fill();
        }

        private void Fill()
        {
            lstCategory.Items.Clear();

            ResultService<Category> result = _categoryBLL.GetAllCategories();

            if (!result.HasError)
            {
                //List<Category> categories = result.ListData;

                //lstCategory.Items.AddRange(categories.Select(x => x.CategoryName).ToArray());

                string[] categoryName = result.ListData.Select(x => x.CategoryName).ToArray();

                lstCategory.Items.AddRange(categoryName);


            }

        }

        private void SelectedIndex(object sender, EventArgs e)
        {
            string categoryName = lstCategory.SelectedItem.ToString();
            txtCategoryName.Text = _categoryBLL.GetCategoryByName(categoryName).Data.CategoryName;
        }

        private void Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            string tag = btn.Tag.ToString();

            switch (tag)
            {
                case "Create":
                    ButtonCreate();
                    break;
                case "Update":
                    ButtonUpdate();
                    break;
                case "Delete":
                    ButtonDelete();
                    break;

                default:
                    break;
            }
        }

        private void ButtonDelete()
        {
            string catogoryName = lstCategory.SelectedItem.ToString();
            ResultService<Category> result = _categoryBLL.GetCategoryByName(catogoryName);

            if (!result.HasError)
            {
                CategoryBaseVM @base = new CategoryBaseVM
                {
                    Id = result.Data.Id
                }; //@ işareti C#'ın keywordlerinden herhangi birini kullanmak istediğimizde başına konulur.

                ResultService<CategoryBaseVM> baseResult = _categoryBLL.DeleteCategoryById(@base.Id);

                if (baseResult.HasError)
                {
                    string errorMessage = baseResult.ErrorItems.First().ErrorMessage;
                    string errorType = baseResult.ErrorItems.First().ErrorType;

                    MessageBox.Show(errorMessage, errorType, MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Silme işlemi başarılı", "Bilgi", MessageBoxButtons.OK);
                    Fill();
                }
            }
            else
            {
                string errorMessage = result.ErrorItems.First().ErrorMessage;
                string errorType = result.ErrorItems.First().ErrorType;

                MessageBox.Show(errorMessage, errorType, MessageBoxButtons.OK);
            }
        }

        private void ButtonUpdate()
        {
            string categoryName = lstCategory.SelectedItem.ToString();
            ResultService<Category> result = _categoryBLL.GetCategoryByName(categoryName);

            if (!result.HasError)
            {
                CategoryUpdateVM vm = new CategoryUpdateVM
                {
                    Name = txtCategoryName.Text,
                    Id = result.Data.Id
                };

                ResultService<CategoryUpdateVM> updateResult = _categoryBLL.UpdateCategory(vm);

                if (updateResult.HasError)
                {
                    string errorMessage = updateResult.ErrorItems.First().ErrorMessage;
                    string errorType = updateResult.ErrorItems.First().ErrorType;

                    MessageBox.Show(errorMessage, errorType, MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Kayıt başarılı","Bilgi",MessageBoxButtons.OK);
                    Fill();
                }
            }
            else
            {
                string errorMessage = result.ErrorItems.First().ErrorMessage;
                string errorType = result.ErrorItems.First().ErrorType;

                MessageBox.Show(errorMessage, errorType, MessageBoxButtons.OK);
            }
        }

        private void ButtonCreate()
        {
            CategoryCreateVM vm = new CategoryCreateVM()
            {
                CategoryName = txtCategoryName.Text
            };
            ResultService<Category> result = _categoryBLL.CreateCategory(vm);

            GetResult(result);
            Fill();
        }

        private void GetResult(ResultService<Category> result)
        {
            if (result.HasError)
            {
                string errorMessage = result.ErrorItems.FirstOrDefault().ErrorMessage;
                string errorType = result.ErrorItems.FirstOrDefault()?.ErrorType;

                MessageBox.Show(errorMessage, errorType, MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Kayıt başarılı", "Bilgi", MessageBoxButtons.OK);
            }
        }
    }
}
