class AddBooksTable < ActiveRecord::Migration[5.0]
  def change
      create_table :books do |t|
        t.references :user, foreign_key: true
        t.references :unique_book, foreign_key: true

        t.timestamps
      end
  end
end
