class RenameBooksTableToUniqueBooksTable < ActiveRecord::Migration[5.0]
  def change
    rename_table :books, :unique_books
  end
end
