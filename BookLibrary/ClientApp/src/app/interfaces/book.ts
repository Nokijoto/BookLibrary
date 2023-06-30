export interface Book {
  id: number;
  bookUuid: string;
  title: string;
  totalPages: number;
  rating: number;
  isbn?: string;
  publishedDate: Date;
  description?: string;
  imageUrl?: string;
}
