class UniqueBooksController < ApplicationController

  def index
    @unique_book = UniqueBook.all
  end

  def show
  end

  def new
    @unique_book = UniqueBook.new(unique_book_params)
  end

  def edit
  end

  def create
    if @unique_book.save
      @book = Book.create(unique_book: @unique_book.id, user_id: current_user.id)
      flash[:success] = "Book created successfully"
      redirect_to user_books_url(current_user)
    else
      render new_user_book_url(current_user)
    end
  end

  def update
  end

  def destroy
  end

end
