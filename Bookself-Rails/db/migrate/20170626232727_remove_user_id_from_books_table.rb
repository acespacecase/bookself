class RemoveUserIdFromBooksTable < ActiveRecord::Migration[5.0]
  def change
    remove_reference :books, :user_id, foreign_key: true
  end
end
