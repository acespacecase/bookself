class CreateTags < ActiveRecord::Migration[5.0]
  def change
    create_table :tags do |t|
      t.string :name
      t.references :book, foreign_key: true

      t.timestamps
    end

    add_index :tags, [:book_id, :created_at]

  end
end
