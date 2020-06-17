export interface IOrder {
  id: number;
  code: string;
  description: string;
  category: string;
  subCategory: string;
  categoryId: number;
  subCategoryId: number;
  price: number;
  quantity: number;
}
