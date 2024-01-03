export default interface IProductCard {
  id: string,
  name: string,
  description: string,
  price: number,
  image: string,
  promotionId: string,
  categoryId: string,
  createdAt: Date,
  updatedAt: Date
}